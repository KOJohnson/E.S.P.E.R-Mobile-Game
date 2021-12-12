using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TDController : MonoBehaviour
{
    private PlayerInput _playerInput;
    private Animator _animator;
    
    [SerializeField]private float playerSpeed;
    [SerializeField] private float velocity;
    [SerializeField] private int velocityHash;
    [SerializeField] private float accerleration = 0.1f;
    [SerializeField] private float deccerleration = 0.1f;

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _animator = GetComponent<Animator>();
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
        velocityHash = Animator.StringToHash("velocity");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movementInput = _playerInput.PlayerMain.Move.ReadValue<Vector2>();
        Vector3 move = new Vector3(movementInput.x, 0, movementInput.y);

        transform.position += move * playerSpeed * Time.deltaTime;
        if (move != Vector3.zero)
        {
            velocity += Time.deltaTime * accerleration;
            transform.rotation = Quaternion.LookRotation(move);
        }

        if(movementInput.x != 0 )



            _animator.SetFloat(velocityHash, velocity);
    }
}
