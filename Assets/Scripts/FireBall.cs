using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{


    public HealthSystem damage;
    
    void Start()
    {
        damage = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthSystem>();
        StartCoroutine(SelfDestruct());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            damage.TakeDamage(10);
            Destroy(gameObject);

        }
        else
        {
            Destroy(gameObject);
        }
    }

    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
