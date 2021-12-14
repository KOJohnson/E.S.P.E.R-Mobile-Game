using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerInput _playerInput;
    [SerializeField]private GameObject cube;
    [SerializeField]private LayerMask layerMask;
    [SerializeField]private float rayLength;
    [SerializeField]private bool isGrounded;
    
    private CharacterController controller;
    private Vector3 playerVelocity;
    //[SerializeField]private bool groundedPlayer;
    [SerializeField]private float playerSpeed = 2.0f;
    [SerializeField]private float jumpHeight = 1.0f;
    [SerializeField]private float gravityValue = -9.81f;


    private void Awake()
    {
        _playerInput = new PlayerInput();
        controller = GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

   
    private void Start()
    {
        
    }

    void Update()
    {
        
        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector2 movementInput = _playerInput.PlayerMain.Move.ReadValue<Vector2>();
        Vector3 move = new Vector3(movementInput.x, 0, movementInput.y);
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            
            gameObject.transform.forward = move;
        }

        // Changes the height position of the player..
        if (_playerInput.PlayerMain.Jump.triggered && isGrounded)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
        
        Shooting();
        GroundCheck();
    }

    private void Shooting()
    {

        if (_playerInput.PlayerMain.Shoot.triggered)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity))
            {
                Debug.DrawRay(transform.position, transform.forward * 1000, Color.red);
                Debug.Log("Shooting");
            }
        }
    }

    private bool GroundCheck()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit, rayLength, layerMask))
        {
            Debug.DrawRay(transform.position, -transform.up * rayLength, Color.red);
            isGrounded = true;
        }
        else isGrounded = false;

        return isGrounded;
        
    }
}

