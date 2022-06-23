using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangeAttack : MonoBehaviour
{
    public float targetDistance;
    public float attackDistance;
    public float projectileForce;
    public float attackDelay;
    private float lastAttack;
    public Transform target;
    public Transform enemy;
    public GameObject FireBall;

    
    void Start()
    {
        

    }

   
    void Update()
    {
        targetDistance = Vector3.Distance(transform.position, target.position);

        if (targetDistance < attackDistance)
        {
            if (Time.time > lastAttack + attackDelay)
            {
                RaycastHit Hit;
                if (Physics.Raycast(enemy.transform.position, enemy.transform.forward, out Hit, LayerMask.NameToLayer("Player")))
                
                                   
                    Debug.DrawLine(enemy.transform.position, enemy.transform.forward, Color.red, LayerMask.NameToLayer("Player"));
                    transform.LookAt(target);
                    Attack();
                    lastAttack = Time.time;
                
            }
        }
    }

    private void Attack()
    {
        GameObject newfireball = Instantiate(FireBall, transform.position + (transform.forward * 1), transform.rotation);
        newfireball.GetComponent<Rigidbody>().AddForce(transform.forward * projectileForce, ForceMode.Impulse);
                
    }
}
