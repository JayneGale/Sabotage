using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Openable : MonoBehaviour
{
    public bool startLocked;
    public bool startClosed;
    public GameObject door;
    MeshRenderer doorRend;
    Collider doorCol;
    Animator doorAnimator;
    [HideInInspector]
    public bool isLocked;
    bool isClosed;
    bool firstCarryOn;
    public List<GameObject> unlockOnceInteracted = new List<GameObject>(); //list of gameobjects to be interacted with before the door/drawer unlocks
    Material material;
 //   int listCount;
    AudioManager AM;


    void Start()
    {
        isLocked = startLocked;
        isClosed = startClosed;
        firstCarryOn = true;
 //       listCount = unlockOnceInteracted.Count;
 
        doorRend = door.GetComponent<MeshRenderer>();
        doorCol = door.GetComponent<Collider>();
        doorAnimator = door.GetComponent<Animator>();

        material = GetComponent<Renderer>().material;
        if (!isLocked)
        {
            material.color = Color.green;
        }

        else material.color = Color.red;
        AM = FindObjectOfType<AudioManager>();
    }

    void FixedUpdate()
    {
        var locked = false;
        foreach (GameObject interactable in unlockOnceInteracted)
        {
            if (!interactable.GetComponent<Readable_J>().hasInteracted)
            {
                locked = true;
                break;
            }
        }
        if (!locked)
        {
            if (isLocked)
            {
                isLocked = false;
                if (CompareTag("Drawer"))
                {
                    AM.Play("Drawer_Unlock");
                }
                else
                {
                    AM.Play("Door_Unlock");
                }
                material.color = Color.green;
            }
        }
        if (isLocked)
        {
            material.color = Color.red;
        }
    }

    public void OpenAndClose()
    {
        if (!isLocked)
        {
            isClosed = !isClosed;
            if (isClosed)
            {
                doorAnimator.SetBool("isOpening", false);
                doorAnimator.SetBool("isClosing", true);

                if (CompareTag("Drawer"))
                {
                    Debug.Log("Play drawer close animation " + name);
                    AM.Play("Drawer_Close");
                }
                else
                {
                    Debug.Log("Play door close animation" + name);
                    AM.Play("Door_Close");
 //                   doorRend.enabled = true;
 //                   doorCol.enabled = true;
 //                   gameObject.GetComponent<MeshRenderer>().enabled = true;

                }
            }

            if (!isClosed)
            {
                isClosed = !isClosed;
                doorAnimator.SetBool("isClosing", false);
                doorAnimator.SetBool("isOpening", true);

                if (CompareTag("Drawer"))
                {
                    Debug.Log("Play drawer open animation " + name);
                    AM.Play("Drawer_Open");
                }
                else
                {
                    Debug.Log("Play door open animation " + name);
                    AM.Play("Door_Open");
 //                   doorRend.enabled = false;
 //                   doorCol.enabled = false;
 //                   gameObject.GetComponent<MeshRenderer>().enabled = false;                  
                }
            }
        }

        else                 //the door is locked, make it rattle
        {
            if (CompareTag("Drawer"))
            {
               AM.Play("DrawerLocked_Rattle_1");
            }
            else
            {
                AM.Play("DoorLocked_Rattle");
                if (firstCarryOn)
                {
                    AM.Play("TakeCarryOn");
                    firstCarryOn = false;
                }
            }

        }
        
    }
}
