using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{
    private Animator anim;
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask isGround, isPlayer;


    //refernce to player health script
    public PlayerHealth playerHealth;


    // Patrolling
    [Header("Patrolling")]
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkRange;

    // Attacking
    [Header("Attacking")]
    public float timeBA; // Time between attacks
    bool Attacked;

    // Attack & Look range
    [Header("Attack & Look range")]
    public float lookRange, attackRange;
    bool playerInLookRange, playerInAttackRange; // Changed types to bool

    [Header("Audio")]
    public AudioManager am;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        // Check if the player is within the look range and attack range of the enemy
        playerInLookRange = Physics.CheckSphere(transform.position, lookRange, isPlayer) ? true : false;
        //? is a operator that checks if the condition inside Physics.CheckSphere is true, it sets playerInLookRange to true otherwise it sets it to false.
        //Essentially, it ensures that playerInLookRange is true if the player is within the look range, and false otherwise.
         playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, isPlayer) ? true : false;

        // Determine the behavior of the enemy based on the player's position
        if (!playerInLookRange && !playerInAttackRange)
            Patrolling(); // If the player is neither in the look range nor the attack range, patrol
        if (playerInLookRange && !playerInAttackRange)
            ChasePlayer(); // If the player is in the look range but not in the attack range, chase
        if (playerInAttackRange && playerInLookRange)
            AttackPlayer(); // If the player is in both the look and attack ranges, attack
    }

    public void Patrolling()
    {
        if (!walkPointSet) //checks for walkpoint
        {
            SearchWalkPoint(); // if not search for onw
        }
           
        if (walkPointSet)
        {
            agent.SetDestination(walkPoint); // walks towards walkpoint if it has been set
             anim.SetBool("Running", false); // Stop running animation
            //anim.SetBool("Walking", true); // Start walking animation
        }
      
        Vector3 distanceToWP = transform.position - walkPoint; // calculates enemy's positoin to the walkpoint.
        if (distanceToWP.magnitude < 1f)
        {
            // if the enemy is close to the walkpoint it is set to false and should find a new point.
            walkPointSet = false;
            //anim.SetBool("Walking", false); // Stop walking animation
        }
        
    }

    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkRange, walkRange); // gets a random z position in range
        float randomX = Random.Range(-walkRange, walkRange); // gets a random x positin in range

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, isGround))
        {
            // make sure that it is ground
            walkPointSet = true;
        }
           
    }
    public void ChasePlayer()
    {
        agent.SetDestination(player.position); // Enemy moves to the player's position
        //anim.SetBool("Walking", false); // Stop walking animation
        anim.SetBool("Running", true); // Start running animation
    }



    private void AttackPlayer()
    {
        agent.SetDestination(transform.position);
        transform.LookAt(player); // make sure it's facing the player

        if (!Attacked)
        {
            Attacked = true;
            playerHealth.TakeDamage(2);
            am.AudioTrigger(AudioManager.SoundFXCat.Damage, transform.position, 1f);
            anim.SetTrigger("Attack"); // Trigger the Attack animation
            Invoke(nameof(ResetAttack), timeBA); // Reset attack after a certain delay
        }
        //anim.SetBool("Walking", false); // Stop walking animation
        anim.SetBool("Running", false); // Stop running animation
    }


    private void ResetAttack()
    {
        Attacked = false;
        anim.SetBool("Attacking", true); // Start attacking animation
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, lookRange);
    }
}


