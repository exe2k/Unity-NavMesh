using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC : MonoBehaviour
{
    NavMeshAgent navAgent;
    Animator anim;
    public Transform Target;


    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Navigate();
    }

    protected void Navigate()
    {
        if (Target == null) return;

        navAgent.destination = Target.position;
        anim.SetBool("Run", (navAgent.remainingDistance >1));

    }
}
