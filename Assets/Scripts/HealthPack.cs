using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    public float healthAmount;
    public PropertyMeter healthMeter;

    private void Start()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
       var hit = other.GetComponent<HealthSystem>();
        if (hit != null)
        {
            hit.playerCurrentHealth = healthAmount;
            healthMeter.UpdateMeter(healthAmount);

            Destroy(gameObject);
        }
    }
}
