using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoorController : MonoBehaviour
{
    public float distance = 2f;
    public AudioClip KeyTakeAudio;
    public AudioClip LockedAudio;
    List<Key> keyList;

    void Start()
    {
        keyList = new List<Key>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, distance))
            {
                if (hit.collider.tag == "Door")
                {
                    LockedDoor door = hit.collider.GetComponent<LockedDoor>();
                    if (door.isLocked)
                    {
                        for (int i = 0; i < keyList.Count; i++)
                        {
                            if (keyList[i].id == door.id)
                            {
                                door.isLocked = false;
                                door.isOpen = !door.isOpen;
                            }
                            else
                            {
                                gameObject.GetComponent<AudioSource>().PlayOneShot(LockedAudio);
                                Debug.Log("Нужен ключ!");
                            }
                        }
                    }
                    else
                    {
                        door.isOpen = !door.isOpen;
                    }

                }
                if (hit.collider.GetComponent<Key>())
                {
                    gameObject.GetComponent<AudioSource>().PlayOneShot(KeyTakeAudio);
                    Key key = hit.collider.GetComponent<Key>();
                    keyList.Add(key);
                    Debug.Log(keyList.Count);
                    Destroy(key.gameObject);
                }
            }
        }
    }
}
