using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5f;

    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;
    DeadPhysics enemy;
    [SerializeField] int damage;
    AudioSource GunSound;
    public ParticleSystem fireEffect;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        enemy = GetComponent<DeadPhysics>();
        GunSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);

        if (isProvoked)
        {
            EngageTarget();
        }
        else if (distanceToTarget <= chaseRange)
        {
            isProvoked = true;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, chaseRange);
    }

    private void EngageTarget()
    {
        if(distanceToTarget >= navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }

        if (distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }
    }

    private void ChaseTarget()
    {
        navMeshAgent.SetDestination(target.position);
    }

    private void AttackTarget()
    {
    }

    public int health = 100;

    public void TakeDamage()
    {
        health -= damage;
        
        if (health <= 0)
        {
            enemy.doRagdoll(true);
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            StartCoroutine(cleanTheBodies());
        }
    }

    IEnumerator cleanTheBodies()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        fireEffect.Play();
        GunSound.Play();
        TakeDamage();
    }
}
