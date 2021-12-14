using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AmmoPickup : MonoBehaviour
{
    private int ammoAmount;
    public string ammoUI;

    private void Awake()
    {
        ammoAmount = Random.Range(3, 11);
        ammoUI = $"Picked up {ammoAmount} ammo";
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("PlayerCol"))
        {
            var ammo = other.GetComponentInChildren<Pistol>();
            GameManager.instance.OpenObjectiveDisplay(ammoUI);
            ammo.currentAmmo += ammoAmount;
            ammo.ammoText.text = ammo.currentAmmo.ToString();
            Destroy(gameObject);
        }
    }
}
