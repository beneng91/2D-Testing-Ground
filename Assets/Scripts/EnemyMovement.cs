using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Transform target;
    NavMeshAgent agent;
    public HealthSystem damage;
    public Animator animator;

    private string currentState = "idleState";

    public int health;
    public int maxHealth;

    public float chaseDistance = 5;
    public int attackStrength;
    public float attackDistance = 2;
    float lastAttack;
    public float attackDelay = 1;
    public float speed = 3;


    IEnumerator Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        damage = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthSystem>();
        health = maxHealth;
        agent = GetComponent<NavMeshAgent>();
        agent.autoTraverseOffMeshLink = false;
        while (true)
        {
            if (agent.isOnOffMeshLink)
            {
                Debug.Log("Mesh link jump");
            }
            yield return null;
        }

    }


    void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);
        agent.destination = target.position;
        

        if (currentState == "idleState")
        {
            if (distance < chaseDistance)
            {
                currentState = "chaseState";
            }
        }
        else if (currentState == "chaseState")
        {
            //run
            animator.SetTrigger("chase");
            animator.SetBool("isAttacking", false);

            if (distance < attackDistance)
            {
                currentState = "attackState";
            }

            //move right
            if (target.position.x > transform.position.x)
            {
                if (distance >= 1.8f)
                {
                    transform.Translate(transform.right * speed * Time.deltaTime);
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                }

            }

            //move left
            else
            {
                if (distance >= 1.8f)
                {
                    transform.Translate(-transform.right * speed * Time.deltaTime);
                    transform.rotation = Quaternion.identity;
                }
                
            }

            if (distance > chaseDistance)
            {
                currentState = "idleState";
            }

        }
        else if (currentState == "attackState")
        {
            animator.SetBool("isAttacking", true);

            if (Time.time > lastAttack + attackDelay)
            {
                //damage.TakeDamage(attackStrength);
                lastAttack = Time.time;
            }

            if (distance > attackDistance)
            {
                currentState = "chaseState";
            }
        }
    }

    public void PlayerTakeDamage()
    {
        damage.TakeDamage(attackStrength);
    }

    public void EnemyTakeDamage(int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        animator.SetTrigger("isDead");

        GetComponent<BoxCollider>().enabled = false;
        this.enabled = false;
    }
}
