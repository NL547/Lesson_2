using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public float radius;
    [Range(0, 360)]
    public float angle;
    public float speed;
    public float attackDistance = 1.5f;

    public GameObject playerRef;

    public LayerMask targetMask;
    public LayerMask obstructionMask;

    public bool canSeePlayer;

    private void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(FOVRoutine());
    }

    void Update()
    {
        if (canSeePlayer == true)
        {
            if (Vector3.Distance(transform.position, playerRef.transform.position) < radius)
            {
                if (Vector3.Distance(transform.position, playerRef.transform.position) > attackDistance)
                {
                    transform.LookAt(playerRef.transform);
                    transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
                    if (Vector3.Distance(playerRef.transform.position, transform.position) < 1.5f)
                    {                       
                        GetComponentInChildren<Animator>().SetTrigger("Atack");                        
                    }
                }
            }
            else
            {
                
            }
        }
    }

    private IEnumerator FOVRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }

    private void FieldOfViewCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                    canSeePlayer = true;
                else
                    canSeePlayer = false;
            }
            else
                canSeePlayer = false;
        }
        else if (canSeePlayer)
            canSeePlayer = false;
    }
}

