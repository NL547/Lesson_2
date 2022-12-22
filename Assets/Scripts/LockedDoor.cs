using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : MonoBehaviour
{
    public static bool doorKey;
    public bool open;
    public bool close;
    public bool inTrigger;

    void Update()
    {
        if (inTrigger)
        {
            if (close)
            {
                if (doorKey)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        open = true;
                        close = false;
                    }
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    open = false;
                    close = true;
                }
            }
        }

        if (inTrigger)
        {
            if (open)
            {
                var newRot = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0.0f, 90.0f, 0.0f), Time.deltaTime * 200);
                transform.rotation = newRot;
            }
            else
            {
                var newRot = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0.0f, 0.0f, 0.0f), Time.deltaTime * 200);
                transform.rotation = newRot;
            }
        }
    }

    void OnGUI()
    {
        if (inTrigger)
        {
            if (open)
            {
                GUI.Box(new Rect(0, 60, 200, 25), "Press E to close");
            }
            else
            {
                if (doorKey)
                {
                    GUI.Box(new Rect(0, 60, 200, 25), "Press E to open");
                }
                else
                {
                    GUI.Box(new Rect(0, 60, 200, 25), "Need a key!");
                }
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        inTrigger = true;
    }
    private void OnTriggerExit(Collider other)
    {
        inTrigger = false;
    }
}

