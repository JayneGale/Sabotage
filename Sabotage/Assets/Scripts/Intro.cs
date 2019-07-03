using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityStandardAssets.Characters.FirstPerson;


public class Intro : MonoBehaviour
{
    public GameObject seatBelt;
    Camera fixedCamera;
    Camera playerCamera;
    GameObject player;
    FirstPersonController playerController;
    Material SeatbeltMat;

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
        playerController = player.GetComponent<FirstPersonController>();
        playerController.enabled = false;

        playerCamera = player.GetComponentInChildren<Camera>();
        playerCamera.enabled = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        SeatbeltMat = seatBelt.GetComponent<Renderer>().material;
        SeatbeltMat.SetColor("_EmissionColor", Color.red * 0.5f);

        //       seatBelt.SetActive(false);
        StartCoroutine(FinishTalking());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
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
        SeatbeltMat.SetColor("_EmissionColor", Color.green * 0.5f);

        //       Cursor.lockState = CursorLockMode.Locked;
        //       Cursor.visible = false;
    }

    IEnumerator FinishTalking()
    {
        yield return new WaitForSeconds(60);
        talking = false;

    }
}
