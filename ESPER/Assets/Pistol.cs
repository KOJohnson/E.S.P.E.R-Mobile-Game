using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    
    private PlayerInput _playerInput;
    [SerializeField] private int pistolDamage;

    public Transform rayOrigin;
    
    private void Awake()
    {
        _playerInput = new PlayerInput();

        pistolDamage = 20;
        
        
        _playerInput.PlayerMain.Shoot.performed += _ => Shooting();
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void Shooting()
    {
        RaycastHit hit;
        if (Physics.Raycast(rayOrigin.position, rayOrigin.forward, out hit, Mathf.Infinity))
        {
            Debug.DrawRay(rayOrigin.position, rayOrigin.forward * 1000, Color.red);

            AiBehaviour target = hit.collider.GetComponent<AiBehaviour>();
            if (target != null)
            {
                target.TakeDamage(pistolDamage);
            }
        }
    }
}
