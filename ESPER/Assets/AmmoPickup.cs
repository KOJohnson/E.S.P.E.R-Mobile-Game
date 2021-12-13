using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AmmoPickup : MonoBehaviour
{
    private int ammoAmount;

    private void Awake()
    {
        ammoAmount = Random.Range(3, 11);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("PlayerCol"))
        {
            var ammo = other.GetComponentInChildren<Pistol>();
            ammo.currentAmmo += ammoAmount;
            ammo.ammoText.text = ammo.currentAmmo.ToString();
            Destroy(gameObject);
        }
    }
}
