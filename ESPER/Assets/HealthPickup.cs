using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class HealthPickup : MonoBehaviour
{
    private int healAmount;

    private void Awake()
    {
        healAmount = Random.Range(10, 21);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.CompareTag("PlayerCol"))
        {
            print("hit");
            var health = other.GetComponentInParent<PlayerStats>();
            if (health.currentHealth != health.maxHealth)
            {
                health.currentHealth += healAmount;
                Destroy(gameObject);
            }
            
        }
    }

}
