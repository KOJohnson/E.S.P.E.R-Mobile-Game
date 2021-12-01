using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInput _playerInput;

    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float rayLength;
    [SerializeField] private bool isGrounded;

    private CharacterController controller;
    private float rotationY;
    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] private float jumpHeight = 1.0f;
    [SerializeField] private float gravityValue = -9.81f;
    [SerializeField] private float rotationSpeed = 3f;

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
    // Start is called before the first frame update
    void Start()
    {
        print(isGrounded);
    }

    // Update is called once per frame
    void Update()
    {
        // if (GameManager.instance.isPaused)
        // { 
        //     OnDisable();
        // }
        // else { OnEnable(); }
        
        
        
        Vector2 movementInput = _playerInput.PlayerMain.Move.ReadValue<Vector2>();
        Vector3 move = new Vector3(movementInput.x, 0, movementInput.y);
        
        transform.position += move * playerSpeed * Time.deltaTime;
        if (move != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(move);
        }
        if (_playerInput.PlayerMain.Jump.triggered && isGrounded)
        {
            // playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }
        
        // transform.Translate(move * playerSpeed * Time.deltaTime, Space.World);

        GroundCheck();
        
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
