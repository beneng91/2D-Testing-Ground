using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallGameOver : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var hit = other.GetComponent<HealthSystem>();
        if (hit != null)
        {
            hit.FellGameOver();           
        }
    }
}
