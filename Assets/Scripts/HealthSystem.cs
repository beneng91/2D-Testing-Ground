using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    //Health
    public float playerHealth = 100;
    public PropertyMeter healthMeter;

    private float playerCurrentHealth = 0;
    void Start()
    {
        playerCurrentHealth = playerHealth;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(int damage)
    {
        playerCurrentHealth -= damage;
        float result = playerCurrentHealth / playerHealth;
        healthMeter.UpdateMeter(result);
    }
}
