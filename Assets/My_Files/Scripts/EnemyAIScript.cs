using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAIScript : MonoBehaviour
{
    public GameObject[] waypoints;
    [SerializeField] private Transform targetPos;

    private NavMeshAgent enemy_NavMeshAgent;
    private Animator enemy_Animator;
    private int waypointIndex;
    private Vector3 prevPosition;
    public float curSpeed;
    public float followRange = 10f;
    public AudioSource punchSound;

    public float attackRange = 3f;
    public Transform attackPoint_Transform;
    public float attackPoint_Range = 2f;
    public bool canAttack;
    // Start is called before the first frame update
    void Start()
    {
        GameObject playerholder = GameObject.FindGameObjectWithTag("Player");
        if (playerholder != null)
        {
            targetPos = playerholder.transform;
        }
        else
        {
            Debug.Log("Player not Found!");
        }
        prevPosition = transform.position;

        waypointIndex = 0;

        enemy_NavMeshAgent = GetComponent<NavMeshAgent>();
        enemy_Animator = GetComponent<Animator>();
        canAttack = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Setting Current Speed for ANIMs
        Vector3 curMove = transform.position - prevPosition;
        curSpeed = curMove.magnitude / Time.deltaTime;
        prevPosition = transform.position;
        enemy_Animator.SetFloat("Speed", curSpeed);

        //Player Detection
        float targetDistance = Vector3.Distance(transform.position, targetPos.position);
        if(targetDistance <= followRange)
        {
            enemy_NavMeshAgent.destination = targetPos.position;

            if(targetDistance <= attackRange && canAttack == true)
            {
                //Attack Player
                canAttack = false;
                enemy_Animator.SetTrigger("Attack");
                punchSound.Play();
            }
        }
        else
        {
            //Waypoints
            float waypointDistance = Vector3.Distance(transform.position, waypoints[waypointIndex].transform.position);
            enemy_NavMeshAgent.destination = waypoints[waypointIndex].transform.position;
            if (waypointDistance < enemy_NavMeshAgent.stoppingDistance + 0.5f)
            {
                waypointIndex++;
                if (waypointIndex >= waypoints.Length)
                {
                    waypointIndex = 0;
                }
            }
        }
    }

    public void Punch()
    {
        Debug.Log("Event Fired");
        Collider[] hitTargets = Physics.OverlapSphere(attackPoint_Transform.position, attackPoint_Range);
        foreach (var target in hitTargets)
        {
            if(target.CompareTag("Player"))
            {
                //Add Damage
                Debug.Log("Attack Hit");
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>().TakeDamage(10);
            }
        }
    }


    public void AttackReset()
    {
        canAttack = true;
        enemy_Animator.ResetTrigger("Attack");
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, followRange);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);

        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(attackPoint_Transform.position, attackPoint_Range);
    }

}
