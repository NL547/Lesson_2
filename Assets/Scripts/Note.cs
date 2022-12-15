using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Note : MonoBehaviour
{
    public GameObject Player;
    private float distance;
    public float interactDistance = 2f;

    public KeyCode Key = KeyCode.E;

    public Text myText;
    public Image myImage;

    public GameObject note;

    void OnMouseOver()
    {
        distance = Vector3.Distance(Player.GetComponent<Transform>().position, transform.position);
        if (distance < interactDistance)
        {
            myText.enabled = true;
            myImage.enabled = true;
            if (Input.GetKeyDown(Key))
            {
                myText.enabled = false;
                myImage.enabled = false;
                GetComponent<BoxCollider>().enabled = false;
                GetComponent<MeshRenderer>().enabled = false;
                note.SetActive (true);
            }            
        }

        if (distance > interactDistance)
        {
            myText.enabled = false;
            myImage.enabled = false;
        }
    }

    void OnMouseExit()
    {
        myText.enabled = false;
        myImage.enabled = false;
    }
}
