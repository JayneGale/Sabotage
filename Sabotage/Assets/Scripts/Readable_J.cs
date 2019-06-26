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


	// Use this for initialization
	void Start () {
        readable2D.SetActive(false);
        closeImage.SetActive(false);
        player = GameObject.FindWithTag("Player"); 
        playerController = player.GetComponent<FirstPersonController>();
    }

public void PickUpReadable()
    {
        readable2D.SetActive(true);
        closeImage.SetActive(true);
        playerController.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;       
    }

    public void PutBackReadable()
    {
        //       readable2D.enabled = false;
        readable2D.SetActive(false);
        closeImage.SetActive(false);
        playerController.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Interact_J.isInteracting = false;
    }


}
