using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public UnityEvent onInteract;
    [HideInInspector]public ElevatorController elevatorController;
    
    private void Awake()
    {
       elevatorController = GetComponent<ElevatorController>();
    }
    public void AddHealth()
    {
        
        Destroy(gameObject);
    }

    public void Ammo()
    {
        
        Destroy(gameObject);
    }

    public void ActivateElevator()
    {
        elevatorController.elevatorOn = true;
    }

    public void KeyCard()
    {
        GameManager.instance.hasKeyCard = true;
    }
    



}
