using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Interact_J : MonoBehaviour {

    public string interactButtonName;
    public Image handIcon;
    public float armDistance = 2.4f;
    public LayerMask interactLayer;
    public bool isInteracting;



	// Use this for initialization
	void Start () {
        Cursor.visible = false;
        if (handIcon == null)
        {
            Debug.Log("No hand icon");
        }
        else handIcon.enabled = false;
            //Cursor.SetCursor(handIcon, Vector2.zero, CursorMode.Auto);      
	}
	
	// Update is called once per frame
	void Update () {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, armDistance, interactLayer))
        {
            if (isInteracting == false)
            {
                handIcon.enabled = true;
            }

            if (Input.GetButtonDown(interactButtonName))
            {
                if (hit.collider.CompareTag("Note"))
                {
                    hit.collider.GetComponent<Readable_J>().PickUpReadable();
                }
                /*                if (hit.collider.CompareTag("Door"))
                                {
                                    hit.collider.GetComponent<Door>().ChangeDoorState();
                                }
                */
                /*                if (hit.collider.CompareTag("Key"))
                                {
                                    hit.collider.GetComponent<Key>().Unlock();
                                }
                */

            }

        }
        else
        {
            handIcon.enabled = false;
        }
	}
}
