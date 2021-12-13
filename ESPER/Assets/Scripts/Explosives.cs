using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosives : MonoBehaviour
{
    private PlayerInput _playerInput;
    public GameObject mine;

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _playerInput.PlayerMain.PlaceMine.performed += _ => PlaceMine();
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }


    private void PlaceMine()
    {
        Instantiate(mine, transform.position, Quaternion.identity);
    }
}
