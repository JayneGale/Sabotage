using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrivalsTrigger : MonoBehaviour
{
    AudioManager AM;

    void Start()
    {
        AM = FindObjectOfType <AudioManager>();
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            AM.Play("NB_Arrivals");
        }    
    }
}
