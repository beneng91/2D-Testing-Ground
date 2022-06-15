using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform target;
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


    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        damage = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthSystem>();
        health = maxHealth;

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
                transform.Translate(transform.right * speed * Time.deltaTime);
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }

            //move left
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
