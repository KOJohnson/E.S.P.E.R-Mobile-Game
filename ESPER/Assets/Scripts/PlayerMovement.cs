using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInput _playerInput;

    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float rayLength;
    [SerializeField] private bool isGrounded;
    
    private Vector3 playerVelocity;
    private float rotationY;
    [SerializeField] private float playerSpeed = 2.0f;
    private void Awake()
    {
        _playerInput = new PlayerInput();
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
        Vector2 movementInput = _playerInput.PlayerMain.Move.ReadValue<Vector2>();
        Vector3 move = new Vector3(movementInput.x, 0, movementInput.y);
        
        transform.position += move * playerSpeed * Time.deltaTime;
        if (move != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(move);
        }
        
        
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
