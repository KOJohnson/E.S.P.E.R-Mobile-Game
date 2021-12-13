using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    private int ammoAmount = 7;
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            var ammo = other.GetComponent<Pistol>();
            ammo.currentAmmo += ammoAmount;
            Destroy(gameObject);
        }
    }
}
