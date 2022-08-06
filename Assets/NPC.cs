using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(AudioSource))]
public class NPC : MonoBehaviour
{
    NavMeshAgent navAgent;
    Animator anim;
    public Transform Target;
    [SerializeField] [Min(0)] float speed;
    const float REACH_DISTANCE = 2f;
    float timeOnTheWay = 0;
    bool isSaidAboutLongWay = false;
    bool isSaidAboutTarget = false;
    bool isSaidAboutNoTarget = false;

    int foundTargets = 0;


    [Header("Audio")]
    AudioSource _as;
    public AudioClip[] finish, target, longWay, targetNull;
    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        _as = GetComponent<AudioSource>();
        if (Target != null)
            navAgent.destination = Target.position;

    }

    void Update()
    {
        timeOnTheWay += Time.deltaTime;
        Navigate();
        CheckHowLongOnWay();
    }

    protected void Navigate()
    {
        if (Target == null)
        {
            if (!isSaidAboutNoTarget)
            {
                Say(targetNull);
            }
            isSaidAboutNoTarget = true;
            return;
        }

        isSaidAboutNoTarget = false;

        if (speed == 0) return;

        navAgent.speed = speed;
        navAgent.destination = Target.position;

        if (navAgent.remainingDistance > REACH_DISTANCE)
        {
            anim.SetBool("Run", true);
            anim.SetBool("Target", false);
            if (isSaidAboutTarget) return;

            if (foundTargets == 0) Say(target, 0);
            else Say(target);

            isSaidAboutTarget = true;
        }

    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag != "Target") return;

        anim.SetBool("Run", false);
        anim.SetBool("Target", true);
        Say(finish);
        isSaidAboutLongWay = false;
        isSaidAboutTarget = false;

        print("Reached! Remaining distance: " + navAgent.remainingDistance);

    }

    private void Say(AudioClip[] clips, int num = -1)
    {
        if (_as.isPlaying) return;

        var rnd = Random.Range(0, clips.Length);
        if (num > -1) rnd = num;
        var clip = clips[rnd];

        _as.PlayOneShot(clip);
    }

    void CheckHowLongOnWay()
    {
        if (timeOnTheWay > 15 && navAgent.remainingDistance > 15 && !isSaidAboutLongWay)
        {
            Say(longWay);
            isSaidAboutLongWay = true;
        }
    }
}
