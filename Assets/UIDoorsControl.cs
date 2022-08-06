using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDoorsControl : MonoBehaviour
{
    [SerializeField] Door[] doors;
    
    public void ActivateDoor(int num)
    {
        doors[num].isUnlocked = !doors[num].isUnlocked;
    }
}
