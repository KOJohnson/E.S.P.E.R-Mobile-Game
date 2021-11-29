using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiBehaviour : MonoBehaviour
{
    [HideInInspector]public AiSensor sensor;
    [HideInInspector]public NavMeshAgent agent;
    
    
    public float distanceToPlayer;
    public float distanceToNextMove;
    public int attackRange;
    [SerializeField]private int rollNumber;
    [SerializeField] private int damage;
    private float _nextFire;
    public float fireRate = 1f;
    
    public bool playerSeen;
    public bool hasPatrolPoints;
    public bool canWander;

    public Transform[] movePaths;
    [SerializeField]private List<Vector3> moveVectors;
    public int moveIndex;

    private GameObject player;
    public Transform minMove;
    public Transform maxMove;
    
   
    void Start()
    {
        sensor = GetComponent<AiSensor>();
        agent = GetComponent<NavMeshAgent>();
        
        if (movePaths.Length > 0)
        {
            hasPatrolPoints = true;
            foreach (Transform movePoint in movePaths)
            {
                var movePointPosition = movePoint.transform.position;
                movePointPosition = new Vector3(movePointPosition.x, movePointPosition.y, movePointPosition.z);
                moveVectors.Add(movePointPosition);
            }
        }
        else {
            hasPatrolPoints = false;
        }
        
        player = null;
        moveIndex = 0;
    }
    
    void Update()
    {
        var position = transform.position;
        distanceToNextMove = Vector3.Distance(position, moveVectors[moveIndex]);
        distanceToPlayer = Vector3.Distance(position, PlayerStats.instance.PlayerPosition);
        
        if (!player) 
        {
            player = FindPlayer();
            if (canWander)
            {
                Wander();
            }
            if (distanceToNextMove < 1 && hasPatrolPoints)
            {
                moveIndex++;
            }
            if (!canWander && hasPatrolPoints)
            {
                FollowPath();
            }
        }

        if (player && distanceToPlayer > attackRange) 
        {
            ChasePlayer();
        }

        if (player && distanceToPlayer <= attackRange)
        {
            agent.speed = 0;
            
            if (Time.time > _nextFire)
            {
                _nextFire = Time.time + fireRate;
                RollDice();
                Attack();
            }
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
        agent.speed = 1;
        agent.destination = player.transform.position;
    }

    private void Attack()
    {
        PlayerStats.instance.PlayerTakeDamage(damage);
    }
    
    private void FollowPath()
    {
        agent.speed = 1;
        agent.SetDestination(moveVectors[moveIndex]);

        if (moveIndex >= moveVectors.Count)
        {
            moveIndex = 0;
        }
    }

    private void RollDice()
    {
        rollNumber = Random.Range(1, 21);

        if (rollNumber < 8)
        {
            damage = 0;
            Debug.Log($"Rolled for {rollNumber}, hit for {damage} damage points");
        }

        if (rollNumber > 8 )
        {
            damage = Random.Range(4, 11);
            Debug.Log($"Rolled for {rollNumber}, hit for {damage} damage points");
        }
    }
    
    private void Wander()
    {
        agent.speed = 1;
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
