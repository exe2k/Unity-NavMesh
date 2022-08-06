using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickToObject : MonoBehaviour
{
    Transform follow;
    void Start()
    {
        if (follow == null)
        {
            follow = transform.GetChild(0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = follow.position;
    }
}
