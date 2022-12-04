using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchTurn : MonoBehaviour
{
    public float smooth = 2.0f;
    public float SwitchTurnAngle = 90.0f;

	public GameObject door;
	public GameObject _switch;

	public AudioClip TurnAudio;
    private bool AudioS;

	private Vector3 defaultRot;
    private Vector3 turnRot;
    private bool turn;
    private bool enter;

    void Start()
    {
        defaultRot = transform.eulerAngles;
        turnRot = new Vector3(defaultRot.x, defaultRot.y + SwitchTurnAngle, defaultRot.z);
    }

    void Update()
    {
		if (turn)
		{
			if (AudioS == false)
			{
				gameObject.GetComponent<AudioSource>().PlayOneShot(TurnAudio);
				AudioS = true;
			}
			transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, turnRot, Time.deltaTime * smooth);
		}
		else
		{
			if (AudioS == true)
			{
				gameObject.GetComponent<AudioSource>().PlayOneShot(TurnAudio);
				AudioS = false;
			}
			transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, defaultRot, Time.deltaTime * smooth);
		}
		if (Input.GetKeyDown(KeyCode.E) && enter)
		{
			turn = !turn;
			door.GetComponent<MechanicalDoor>().FunctionOpen();			
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
