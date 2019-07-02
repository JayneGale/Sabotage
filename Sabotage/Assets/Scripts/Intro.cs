using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityStandardAssets.Characters.FirstPerson;


public class Intro : MonoBehaviour
{
    Camera fixedCamera;
    Camera playerCamera;
    GameObject player;
    FirstPersonController playerController;

    AudioSource s;
    bool talking = true;

    void Start()
    {
        s = GetComponent<AudioSource>();
        talking = true;
        s.Play();
        fixedCamera = GetComponent<Camera>();
        if (fixedCamera == null)
        {
            Debug.Log("No fixed camera present");
        }
        else
        {
            fixedCamera.enabled = true;
        }
        player = GameObject.FindWithTag("Player");
        if (player == null)
        {
            Debug.Log("No player assigned");
        }
        Debug.Log("Disabling player controller and camera");
        playerController = player.GetComponent<FirstPersonController>();
        playerController.enabled = false;
        playerCamera = player.GetComponentInChildren<Camera>();
        playerCamera.enabled = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        //       seatBelt.SetActive(false);
        StartCoroutine(FinishTalking());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Debug.Log("Tab!");
            s.Stop();
            talking = false;
        }

        if (!talking)
        {
            PlayerOn();
        }         
    }

 /*   void SeatBeltOn() {
        seatBelt.SetActive(true);
    }
*/
    void PlayerOn()
    {
        fixedCamera.enabled = false;
        playerCamera.enabled = true;
        playerController.enabled = true;
 //       Cursor.lockState = CursorLockMode.Locked;
 //       Cursor.visible = false;
    }

    IEnumerator FinishTalking()
    {
        talking = false;
        yield return new WaitForSeconds(71);
    }
}
