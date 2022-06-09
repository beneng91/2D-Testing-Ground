using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform target;
    private string currentState = "idleState";

    public float chaseDistance = 5;
    public float attackDistance = 2;
    public float speed = 3;


    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }


    void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);
        

        if (currentState == "idleState")
        {
            if (distance < chaseDistance)
            {
                currentState = "chaseState";
            }
        }
        else if (currentState == "chaseState")
        {
            if (distance < attackDistance)
            {
                currentState = "attackState";
            }

            if (target.position.x > transform.position.x)
            {
                transform.Translate(transform.right * speed * Time.deltaTime);
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }

            else
            {
                transform.Translate(-transform.right * speed * Time.deltaTime);
                transform.rotation = Quaternion.identity;
            }

            if (distance > chaseDistance)
            {
                currentState = "idleState";
            }

        }
        else if (currentState == "attackState")
        {
            if (distance > attackDistance)
            {
                currentState = "chaseState";
            }
        }
    }
}
