using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : MonoBehaviour
{
    [SerializeField] float openDoor;
    [SerializeField] float closeDoor;
    [SerializeField] float speed = 1;

    public bool isOpen;
    public bool isLocked;
    public int id;

    public AudioClip OpenAudio;
    public AudioClip CloseAudio;

    void Update()
    {
        if (isOpen)
        {
            gameObject.GetComponent<AudioSource>().PlayOneShot(OpenAudio);
            OpenDoor();
        }
        else
        {
            gameObject.GetComponent<AudioSource>().PlayOneShot(CloseAudio);
            CloseDoor();
        }
    }

    void OpenDoor()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(transform.rotation.x, openDoor, transform.rotation.z), speed * Time.deltaTime);
    }
    void CloseDoor()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(transform.rotation.x, closeDoor, transform.rotation.z), speed * Time.deltaTime);
    }

}

