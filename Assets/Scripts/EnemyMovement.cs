using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum OffMeshLinkMoveMethod
{
    Parabola,
}

public class EnemyMovement : MonoBehaviour
{
    public Transform target;
    NavMeshAgent agent;


    public Animator animator;

    private string currentState = "idleState";

    public OffMeshLinkMoveMethod m_Method = OffMeshLinkMoveMethod.Parabola;

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
        health = maxHealth;
        

        

        //Enemy jumping over gaps
        agent = GetComponent<NavMeshAgent>();
        agent.autoTraverseOffMeshLink = false;
        while (true)
        {
            if (agent.isOnOffMeshLink)
            {
                animator.SetTrigger("jump");
                if (m_Method == OffMeshLinkMoveMethod.Parabola)
                    yield return StartCoroutine(Parabola(agent, 2.0f, 0.5f));


                agent.CompleteOffMeshLink();
            }
            yield return null;
        }

        

    }
    IEnumerator Parabola(NavMeshAgent agent, float height, float duration)
    {
        OffMeshLinkData data = agent.currentOffMeshLinkData;
        Vector3 startPos = agent.transform.position;
        Vector3 endPos = data.endPos + Vector3.up * agent.baseOffset;
        float normalizedTime = 0.0f;
        while (normalizedTime < 1.0f)
        {
            float yOffset = height * 4.0f * (normalizedTime - normalizedTime * normalizedTime);
            agent.transform.position = Vector3.Lerp(startPos, endPos, normalizedTime) + yOffset * Vector3.up;
            normalizedTime += Time.deltaTime / duration;
            yield return null;
        }
    }


    void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);
        agent.destination = target.position;

        

        if (currentState == "idleState")
        {
            animator.SetTrigger("idle");

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

                    if (target.position.x > transform.position.x + 0.015f)
                    {
                        transform.rotation = Quaternion.Euler(0, 180, 0);
                    }

                }

            }

            //move left
            else
            {
                if (distance >= 1.8f)
                {
                    transform.Translate(-transform.right * speed * Time.deltaTime);
                    

                    if(distance > 1f)
                    {
                        transform.rotation = Quaternion.identity;
                    }

                }
                
            }

            if (distance > chaseDistance)
            {
                animator.SetTrigger("idle");

                currentState = "idleState";
            }



        }
        else if (currentState == "attackState")
        {
            animator.SetBool("isAttacking", true);

            if (Time.time > lastAttack + attackDelay)
            {                
                lastAttack = Time.time;
            }

            if (distance > attackDistance)
            {
                currentState = "chaseState";
            }
        }        
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
