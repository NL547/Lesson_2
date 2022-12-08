using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bullet_hole_1;
    [SerializeField] private Transform bullet_hole_2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
           GameObject bullet_ins =  Instantiate(bullet,bullet_hole_1.position,Quaternion.identity);
           Bullet b = bullet_ins.GetComponent<Bullet>();
           b.SetEnemy(other.gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        transform.LookAt(other.gameObject.transform);        
    }
}
