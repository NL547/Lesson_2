using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public GameObject Enemy;
    public int hp = 100;

    void Update()
    {
        if (hp > 100)
        {
            hp = 100;
        }
        if (hp < 1)
        {
            Enemy.SetActive(false);
        }
    }
}
