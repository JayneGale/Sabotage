using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;


public class Readable_J : MonoBehaviour
{
    public GameObject readable2D;
    public GameObject closeImage;
    GameObject player;
    FirstPersonController playerController;
    [HideInInspector]
    public bool hasInteracted = false;
    AudioManager AM;
    // Use this for initialization
    void Start ()
    {
        readable2D.SetActive(false);
        closeImage.SetActive(false);
        player = GameObject.FindWithTag("Player"); 
        playerController = player.GetComponent<FirstPersonController>();
        AM = FindObjectOfType<AudioManager>();
    }

    public void PickUpReadable()
    { 
        gameObject.SetActive(false);
        readable2D.SetActive(true);
        closeImage.SetActive(true);
        if (CompareTag("Note"))
        {
            AM.Play("Note_PickUp2");
        }
        else
        {
            AM.Play("Book_PickUp");
        }

        playerController.enabled = false;    
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;       
    }

    public void PutBackReadable()
    {
        gameObject.SetActive(true);
        readable2D.SetActive(false);
        closeImage.SetActive(false);
        if (CompareTag("Note"))
        {
            AM.Play("Note_PutDown");
        }
        else
        {
            AM.Play("Book_PutDown");
        }

        playerController.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Interact_J.isInteracting = false;
        hasInteracted = true;
    }


}
