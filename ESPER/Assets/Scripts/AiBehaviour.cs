using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiBehaviour : MonoBehaviour
{
    [HideInInspector]public AiSensor sensor;
    [HideInInspector]public NavMeshAgent agent;

    [SerializeField] private int currentHealth;
    [SerializeField] private int maxHealth = 100;
    
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
        
        currentHealth = maxHealth;
        
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
            if (distanceToNextMove < 2 && hasPatrolPoints)
            {
                moveIndex++;
                if (moveIndex >= moveVectors.Count)
                {
                    moveIndex = 0;
                }
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

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0 )
        {
            Destroy(gameObject);
            GameManager.instance.enemyKillCount++;
            GameManager.instance.scoreCount += 10;
        }
    }
    
    private void FollowPath()
    {
        //sets agent speed to 1 
        //sets the agent destination to the vector 3 value to the current index in moveVector array
        agent.speed = 1;
        agent.SetDestination(moveVectors[moveIndex]);
        
    }

    private void RollDice()
    {
        //When called this will generate a random number between given values
        //if current value is more than 8 we can add damage, if it is less than 8 then damage is 0
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
        //if the agent navmesh does not have a path and canWander is true we assign a random path  but generating
        //vector 3 values in between a set min and max movement area
        //then we set the randomly generated Vector 3 to the agents current destination
        
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
