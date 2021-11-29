using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorController : MonoBehaviour
{
    public bool elevatorOn;
    [SerializeField]private GameObject platform;
    [SerializeField]private Transform platformTarget;
    [SerializeField] private float elevatorSpeed;
    
    void Update()
    {
        if (elevatorOn)
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
