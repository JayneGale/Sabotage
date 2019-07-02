using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoorOnExit : MonoBehaviour
{
    public GameObject door;
    MeshRenderer doorRend;
    AudioManager AM;
    // Use this for initialization
    void Start()
    {
        AM = FindObjectOfType <AudioManager>();
        doorRend = door.GetComponent<MeshRenderer>();
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player exits; play close door animation");
            doorRend.enabled = true;
            gameObject.GetComponent <MeshRenderer>().enabled=true;

            AM.Play("Door_Close"); //add coroutine so not overlapped
            AM.Play("Welcome");
        }    
    }
}
