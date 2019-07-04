using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoorOnExit : MonoBehaviour
{
    public GameObject door;
    public bool lockOnExit;
    AudioManager AM;
    Animator doorAnimator;
    bool firstExit = true;


    void Start()
    {
        AM = FindObjectOfType <AudioManager>();
        doorAnimator = door.GetComponent<Animator>();
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player exits; play close door animation");
            doorAnimator.SetBool("isOpening", false);
            if (lockOnExit)
            {
                door.GetComponent<Openable>().isLocked = true;
                door.GetComponent<Openable>().isClosed = true;
            }
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
