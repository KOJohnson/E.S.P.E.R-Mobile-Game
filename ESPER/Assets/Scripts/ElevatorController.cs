using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorController : MonoBehaviour
{
    public bool moveElevatorUp;
    public bool moveElevatorDown;
    [SerializeField]private GameObject platform;
    [SerializeField]private Transform platformTarget;
    [SerializeField]private float elevatorSpeed;
    [SerializeField] private float distance;
    private Vector3 originalPos;

    private void Start()
    {
        var position = transform.position;
        originalPos = new Vector3(position.x, position.y, position.z);
    }

    void Update()
    {
        //distance = Vector3.Distance(platform.transform.position, platformTarget.position);
        if (moveElevatorUp)
        {
            MoveUp();
        }
    }

    private void MoveUp()
    {
        platform.transform.position = Vector3.Lerp(platform.transform.position, platformTarget.position, elevatorSpeed);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(platform.transform.position, platformTarget.position);
    }
}
