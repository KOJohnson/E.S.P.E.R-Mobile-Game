using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

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
        // When ammo is picked up destroy and replenish ammo to max value
        // Ammo = MaxAmmo
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
    }

    public void ActivateDoor()
    {
        doorController.anim.Play("DoorOpen");
        StartCoroutine(CloseDoor());
    }

    public void EndGame()
    {
        if (GameManager.instance.hasKeyCard)
        {
            GameManager.instance.fadeOut.SetActive(true);
            doorController.anim.Play("DoorOpen");
            SceneManager.LoadScene("End Scene");
        }
        
    }

    private IEnumerator CloseDoor()
    {

        yield return new WaitForSeconds(5);
        doorController.anim.Play("DoorClose");
        
    }
    
    



}
