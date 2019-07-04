using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoorOnExit : MonoBehaviour
{
    public GameObject door;
    MeshRenderer doorRend;
    AudioManager AM;
    Animator doorAnimator;
    bool firstExit = true;

    void Start()
    {
        AM = FindObjectOfType <AudioManager>();
        doorAnimator = door.GetComponent<Animator>();

//        doorRend = door.GetComponent<MeshRenderer>();
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player exits; play close door animation");
            doorAnimator.SetBool("isOpening", false);
            doorAnimator.SetBool("isClosing", true);

            //           doorRend.enabled = true;
            //          gameObject.GetComponent <MeshRenderer>().enabled=true;

            AM.Play("Door_Close"); //add coroutine so not overlapped
            if (firstExit)
            {
                AM.Play("NB_Arrivals");
                firstExit = false;
                //AM.Play("Welcome");
            }
        }
    }
}
