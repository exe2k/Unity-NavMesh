using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC : MonoBehaviour
{
    NavMeshAgent navAgent;
    Animator anim;
    public Transform Target;
    [SerializeField] [Min(0)] float speed;
    const float REACH_DISTANCE = 2f;

    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        navAgent.destination = Target.position;
    }

    void Update()
    {
        Navigate();
    }

    protected void Navigate()
    {
        if (Target == null || speed == 0) return;

        navAgent.speed = speed;
        navAgent.destination = Target.position;

        if (navAgent.remainingDistance > REACH_DISTANCE)
        {
            anim.SetBool("Run", true);
            anim.SetBool("Target", false);

        }

    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag != "Target") return;

        anim.SetBool("Run", false);
        anim.SetBool("Target", true);
        print("Reached! Remaining distance: "+ navAgent.remainingDistance);

    }


}
