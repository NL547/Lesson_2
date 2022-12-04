using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDoor : MonoBehaviour
{
	public AudioClip OpenAudio;
	public AudioClip CloseAudio;

	public float smooth = 2.0f;
	public float DoorOpenAngle = 90.0f;

	private Vector3 defaultRot;
	private Vector3 openRot;

	private bool AudioS;
	private bool open;
	
	void Start()
	{
		defaultRot = transform.eulerAngles;
		openRot = new Vector3(defaultRot.x, defaultRot.y + DoorOpenAngle, defaultRot.z);
	}

	void Update()
	{
		if (open)
		{
			if (AudioS == false)
			{
				gameObject.GetComponent<AudioSource>().PlayOneShot(OpenAudio);
				AudioS = true;
			}
			transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, openRot, Time.deltaTime * smooth);
		}
		else
		{
			if (AudioS == true)
			{
				gameObject.GetComponent<AudioSource>().PlayOneShot(CloseAudio);
				AudioS = false;
			}
			transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, defaultRot, Time.deltaTime * smooth);
		}
	}

	public void FunctionOpen()
	{
		open = !open;
	}
}
