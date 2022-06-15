using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int damage = 50;
    


    private void OnTriggerEnter(Collider other)
    {
        var hit = other.GetComponent<EnemyMovement>();
        if (hit != null)
        {
            Debug.Log("I dealt damage");
            hit.EnemyTakeDamage(damage);
            
        }
    }
}
