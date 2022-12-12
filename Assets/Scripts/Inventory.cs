using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool show = false;
    public GUISkin skin;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            show = !show;
        }
    }

    void OnGUI()
    {
        if(show)
        {
            GUI.skin = skin;
            GUI.Window(0, new Rect(0f, 0f, Screen.width, Screen.height), InventoryBody, "Inventory");
        }
    }
    
    void InventoryBody(int id)
    {

    }
}
