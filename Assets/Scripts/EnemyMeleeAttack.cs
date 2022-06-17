using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeAttack : MonoBehaviour
{
    public HealthSystem damage;
    public int attackStrength;

    private void Start()
    {
        {
            damage = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthSystem>();

        }
    }
    public void PlayerTakeDamage()
    {
        damage.TakeDamage(attackStrength);
    }
}
