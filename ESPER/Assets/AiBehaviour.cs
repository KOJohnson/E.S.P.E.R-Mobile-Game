using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiBehaviour : MonoBehaviour
{
    [HideInInspector]public AiSensor sensor;
    [HideInInspector]public NavMeshAgent agent;

    public float distanceToPLayer;
    public float distanceToNextMove;
    public int attackRange;
    
    public bool playerSeen;
    public bool canWander;

    public Transform[] movePaths;
    [SerializeField]private List<Vector3> moveVectors;

    private GameObject player;
    public Transform minMove;
    public Transform maxMove;
    
    // Start is called before the first frame update
    void Start()
    {
        sensor = GetComponent<AiSensor>();
        agent = GetComponent<NavMeshAgent>();
        
        foreach (Transform movePoint in movePaths)
        {
            var movePointPosition = movePoint.transform.position;
            movePointPosition = new Vector3(movePointPosition.x, movePointPosition.y, movePointPosition.z);
            moveVectors.Add(movePointPosition);
        }
        
        player = null;
    }

    // Update is called once per frame
    void Update()
    {

        if (!player) {
            player = FindPlayer();
            if (canWander) {
                Wander();
            }
            else
            {
                FollowPath();
            }
        }

        if (player) {
            ChasePlayer();
        }
        
    }

    private GameObject FindPlayer()
    {
        if (sensor.Objects.Count > 0)
        {
            playerSeen = true;
            return sensor.Objects[0];
        }
        return null;
    }

    private void ChasePlayer()
    {
        agent.destination = player.transform.position;
    }

    private void Attack()
    {
        Debug.Log("do something");
    }
    
    private void FollowPath()
    {
        for (int i = 0; i < moveVectors.Count;)
        {
            agent.SetDestination(moveVectors[i]);
            distanceToNextMove = Vector3.Distance(transform.position, moveVectors[i]);
            print(i);
        }
        

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
