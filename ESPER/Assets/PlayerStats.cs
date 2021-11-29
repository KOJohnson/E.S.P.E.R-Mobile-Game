using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats instance;
    
    public Vector3 PlayerPosition {get; private set;}
    public float currentHealth;
    public float maxHealth = 100f;
    // public HealthBar healthBar;

   private void Awake()
    {
        if (instance == null) //check if instance is null
        {
            instance = this; // assign instance to this instance of the class
        }
        else if (instance != this) //check if this instance has already been assigned elsewhere
        {
            Destroy(gameObject); //destroy manager if one already exists in the scene
        }
    }
    
    void Start()
    {
        currentHealth = maxHealth;
        // if (healthBar != null)
        // {
        //     healthBar.SetMaxHealth(maxHealth);
        // }
    }
    
    void Update()
    {
        PlayerPosition = transform.position;
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
    }

    public void PlayerTakeDamage(float damage)
    {
        currentHealth -= damage;
        //healthBar.SetHealth(currentHealth);
        
        if (currentHealth <= 0)
        {
            //GameManager.instance.playerDead = true;
        }
    }

    private void Die()
    {
        throw new NotImplementedException();
    }

}
