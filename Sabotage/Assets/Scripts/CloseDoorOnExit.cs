using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoorOnExit : MonoBehaviour
{
    AudioManager AM;
    // Use this for initialization
    void Start()
    {
        AM = FindObjectOfType <AudioManager>();
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player exits; play close door animation");
            AM.Play("Door_Close");
        }    
    }
}
