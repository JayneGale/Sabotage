using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Readable_J : MonoBehaviour
{
    public Image readable2D; 


	// Use this for initialization
	void Start () {
        readable2D.enabled = false;
		
	}

public void PickUpReadable()
    {
        readable2D.enabled = true;

    }

    public void PutBackReadable()
    {
        readable2D.enabled = false;

    }


}
