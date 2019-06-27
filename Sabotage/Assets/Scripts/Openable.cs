using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Openable : MonoBehaviour
{
    public bool startLocked;
    public bool startClosed;
    [HideInInspector]
    public bool isLocked;
    bool isClosed;
    public List<GameObject> unlockOnceInteracted = new List<GameObject>(); //list of gameobjects to be interacted with before the door/drawer unlocks
    Material material;
    int listCount;

    void Start()
    {
        isLocked = startLocked;
        isClosed = startClosed;
        listCount = unlockOnceInteracted.Count;
        Debug.Log("List size is " + listCount);
        material = GetComponent<Renderer>().material;
        if (!isLocked)
        {
            material.color = Color.green;
        }

        else material.color = Color.red;
    }

    void FixedUpdate()
    {
        var locked = false;
        foreach (GameObject interactable in unlockOnceInteracted)
        {
            if (!interactable.GetComponent<Readable_J>().hasInteracted)
            {
                locked = true;
                break;
            }
        }
        if (!locked)
        {
            if (isLocked)
            {
                isLocked = false;
                if (CompareTag("Drawer"))
                {
                    Debug.Log("Play drawer unlock Audioclip " + name);
                }
                else Debug.Log("Play door unlock Audioclip " + name);
                material.color = Color.green;
            }
        }
        if (isLocked)
        {
            material.color = Color.red;
        }
    }

    public void OpenAndClose()
    {
        if (!isLocked)
        {
            isClosed = !isClosed;
            if (isClosed)
            {
                if (CompareTag("Drawer"))
                {
                    Debug.Log("Play drawer close animation and audioclip");
                }
                else Debug.Log("Play door close animation and audioclip " + name);
            }

            if (!isClosed)
            {
                if (CompareTag("Drawer"))
                {
                    Debug.Log("Play drawer open animation and audiociip");
                }
                else Debug.Log("Play door open animation and audioclip");
                //play door open or close animation and audioclip
            }
        }

        else
        {
            Debug.Log("Play door Locked rattle Audioclip");
        }

    }
}
