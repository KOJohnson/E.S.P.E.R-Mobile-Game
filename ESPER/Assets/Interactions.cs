using System;
using UnityEngine;
using UnityEngine.Events;


public class Interactions : MonoBehaviour
{  
    [SerializeField] LayerMask interactableLayer;
    [SerializeField] private int maxDistance = 5;
    private UnityEvent onInteract;
    private PlayerInput _playerInput;

    public Transform rayOrigin;
    
    private void Awake()
    {
        _playerInput = new PlayerInput();

        _playerInput.PlayerMain.Interact.performed += _ => RayCastInteract();
        _playerInput.PlayerMain.Pause.performed += _ => GameManager.instance.OnPause();

    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    // private void Update()
    // {
    //     if (GameManager.instance.isPaused)
    //     {
    //         OnDisable();
    //     }
    //     else { OnEnable(); }
    // }

    private void RayCastInteract()
    {
        RaycastHit Hit;
        if (Physics.Raycast(rayOrigin.transform.position, rayOrigin.transform.forward, out Hit, maxDistance, interactableLayer))
        {
            Debug.Log(Hit.transform.name);
            if (Hit.collider.GetComponent<Interactable>() != false)
            {
                onInteract = Hit.collider.GetComponent<Interactable>().onInteract;
                onInteract.Invoke();
            }
        }
    }
    
}
