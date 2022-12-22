using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour
{
    public GameObject Player;
    public int hp = 100;
    public GUISkin skin;

    public int x, y, x1, y1;

    void Update()
    {
        if(hp > 100)
        {
            hp = 100;
        }
        if(hp < 1)
        {
            Player.SetActive(false);
        }
    }

    void OnGUI()
    {
        GUI.skin = skin;
        GUI.Box(new Rect(7, 7, 200, 30), "Health : " + hp + "/ 100");
    }
}
