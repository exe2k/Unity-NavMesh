using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    public Transform follow;
    float speed = 10;
  
    void Update()
    {
        if (follow != null)
        
        transform.position = follow.position;
        transform.rotation = follow.rotation ;
    }
}
