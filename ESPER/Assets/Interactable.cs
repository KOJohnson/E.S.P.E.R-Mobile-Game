using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public UnityEvent onInteract;
    [HideInInspector]public ElevatorController elevatorController;
    [HideInInspector]public DoorController doorController;

    [HideInInspector]public string keyUIText;
    
    private void Awake()
    {
       elevatorController = GetComponent<ElevatorController>();
       doorController = GetComponent<DoorController>();
       keyUIText = "Picked up Key";
       

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
        if (GameManager.instance.hasKeyCard)
        {
            elevatorController.moveElevatorUp = true;
        }
    }

    public void KeyCard()
    {
        GameManager.instance.hasKeyCard = true;
        GameManager.instance.OpenObjectiveDisplay(keyUIText);
        StartCoroutine(GameManager.instance.CloseObjectiveDisplay());

    }

    public void ActivateDoor()
    {
        doorController.anim.Play("DoorOpen");
        StartCoroutine(CloseDoor());
    }

    private IEnumerator CloseDoor()
    {

        yield return new WaitForSeconds(5);
        doorController.anim.Play("DoorClose");
        
    }
    



}
