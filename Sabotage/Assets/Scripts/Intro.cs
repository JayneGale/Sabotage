using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Intro : MonoBehaviour
{

    AudioSource s;
    GameObject seatBelt;
    bool talking = true;

    void Start()
    {
        s = GetComponent<AudioSource>();
        seatBelt.SetActive(false);
        s.Play();
        StartCoroutine(FinishTalking());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            s.Stop();
            talking = false;
        }

        if (!talking)
            SeatBeltOn();
    }

    void SeatBeltOn()
    {
        seatBelt.SetActive(true);
    }

    IEnumerator FinishTalking()
    {
        talking = false;
        yield return new WaitForSeconds(71);
    }
}
