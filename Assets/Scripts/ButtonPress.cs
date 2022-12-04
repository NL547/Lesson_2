using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : MonoBehaviour
{
	public GameObject door;

	private bool enter;
	private bool press;

	public AudioClip PressAudio;
	private bool AudioS;

	void Update()
	{
		if (press)
		{
			if (AudioS == false)
			{
				gameObject.GetComponent<AudioSource>().PlayOneShot(PressAudio);
				AudioS = true;
			}			
		}
		else
		{
			if (AudioS == true)
			{
				gameObject.GetComponent<AudioSource>().PlayOneShot(PressAudio);
				AudioS = false;
			}			
		}
		if (Input.GetKeyDown(KeyCode.E) && enter)
		{
			press = !press;
			door.GetComponent<ButtonDoor>().FunctionOpen();
		}
	}
	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Player")
		{
			enter = true;
		}
	}

	void OnTriggerExit(Collider col)
	{
		if (col.tag == "Player")
		{
			enter = false;
		}
	}
}
