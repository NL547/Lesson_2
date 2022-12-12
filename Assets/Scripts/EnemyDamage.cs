using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu ("My components/Enemy/EnemyDamage")]
public class EnemyDamage : MonoBehaviour
{
    public int damage = 10;

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            col.GetComponent<HP>().hp -= (damage);
        }
    }
}
