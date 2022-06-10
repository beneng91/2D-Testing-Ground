using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    public int attackStrength;
    public float attackDistance;

    public float attackDelay = 1;
    private float lastAttack;

    public Transform target;
    public EnemyHealth damage;
    

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Enemy").transform;

        damage = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyHealth>();
    }

    
    void Update()
    {
        if (Input.GetKeyDown("left ctrl"))
        {
            Attack();
        }
        
    }
    public void Attack()
    {
        float distance = Vector3.Distance(transform.position, target.position);

        if (Time.time > lastAttack + attackDelay && distance < attackDistance )
        {
            damage.EnemyTakeDamage(attackStrength);
            lastAttack = Time.time;
        }
    }
}
