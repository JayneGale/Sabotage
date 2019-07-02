using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpAble : MonoBehaviour {
 //   public Openable myDoorOrDrawer;
    AudioManager AM;

    void Start ()
    {
        AM = FindObjectOfType<AudioManager>();
    }

    public void PickUp()
    {
        Debug.Log("Pickup called on" + name);
        if (CompareTag("Key") || CompareTag("Crystal"))
        {
            AM.Play("CrystalKey_Pickup");
            gameObject.SetActive(false);
  //          myDoorOrDrawer.isLocked = false;
        }
        else AM.Play("Note_PutDown2");
    }
}
