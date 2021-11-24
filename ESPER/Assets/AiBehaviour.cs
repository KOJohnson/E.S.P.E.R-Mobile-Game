using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiBehaviour : MonoBehaviour
{
    [HideInInspector]public AiSensor sensor;
    [HideInInspector]public NavMeshAgent agent;

    private GameObject player;

    public Transform minMove;
    public Transform maxMove;
    
    // Start is called before the first frame update
    void Start()
    {
        sensor = GetComponent<AiSensor>();
        agent = GetComponent<NavMeshAgent>();

        player = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (!player)
        {
            player = FindPlayer();
            Wander();
        }

        if (player)
        {
            ChasePlayer();
        }
    }

    private GameObject FindPlayer()
    {
        if (sensor.Objects.Count > 0)
        {
            return sensor.Objects[0];
        }
        return null;
    }

    private void ChasePlayer()
    {
        agent.destination = player.transform.position;
    }
    

    private void Wander()
    {
        if (!agent.hasPath)
        {
            Vector3 min = minMove.position;
            Vector3 max = maxMove.position;

            Vector3 randomPosition = new Vector3(
                Random.Range(min.x, max.x),
                Random.Range(min.y, max.y),
                Random.Range(min.z, max.z)
            );

            agent.destination = randomPosition;
        }
        
    }
}
