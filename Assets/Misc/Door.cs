using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] AudioClip clip;
    AudioSource audioSource;
    public bool isUnlocked;
    [SerializeField] float speed = 2;
    bool isInit=false;
    float offsetY = 4.5f;
    GameObject realDoor;

    private void Update()
    {
        LockDoor();
    }


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        offsetY *= transform.lossyScale.y;
        realDoor = transform.GetChild(0).gameObject;
    }

    public void LockDoor()
    {

        if (isUnlocked)
        {
           if (realDoor.transform.localPosition.y == 0 && isInit)
                audioSource.PlayOneShot(clip);

            realDoor.transform.localPosition =
                Vector3.MoveTowards(realDoor.transform.localPosition, new Vector3(0, -offsetY), speed * Time.deltaTime);

            isInit = true;
        }
        else
        {
            if (realDoor.transform.localPosition.y == -offsetY)
                audioSource.PlayOneShot(clip);

            realDoor.transform.localPosition =
                Vector3.MoveTowards(realDoor.transform.localPosition, Vector3.zero, speed * Time.deltaTime);
        }

    }
}
