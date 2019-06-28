using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;


public class Interact_J : MonoBehaviour
{

    public string interactButtonName;
    public Image handIcon;
    public float armDistance = 3f;
    public LayerMask interactLayer;
    public static bool isInteracting = false;

	// Use this for initialization
	void Start ()
    {
        if (handIcon == null)
        {
            Debug.Log("No hand icon");
        }
        else handIcon.enabled = false;
        //Cursor.SetCursor(handIcon, Vector2.zero, CursorMode.Auto);    
            }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, armDistance, interactLayer))
        {
            if (!isInteracting)
            {
                handIcon.enabled = true;
            }

            if (Input.GetButtonDown(interactButtonName))
            {
                Debug.Log("Got a hit with tag " + hit.collider.tag);
                if (hit.collider.CompareTag("Note")|| hit.collider.CompareTag("Book"))
                {
                    hit.collider.GetComponent<Readable_J>().PickUpReadable();
                    isInteracting = true;
                }
                if (hit.collider.CompareTag("Door") || hit.collider.CompareTag("Drawer"))
                {
                    hit.collider.GetComponent<Openable>().OpenAndClose();
                }
               
                if (hit.collider.CompareTag("Key") || hit.collider.CompareTag("Crystal"))
                {
                    Debug.Log("Pick Up Key or Crystal");
                    hit.collider.GetComponent<PickUpAble>().PickUp();
                }
            }
        }
        else
        {
            handIcon.enabled = false;
        }
	}
}
