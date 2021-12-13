using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    private int healAmount = 20;

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.CompareTag("Player"))
        {
            var health = other.GetComponent<PlayerStats>();
            health.currentHealth += healAmount;
            Destroy(gameObject);
        }
    }

}
