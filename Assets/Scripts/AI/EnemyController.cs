using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    Enemy _enemy;
    EnemyAnimator enemyAnimator;
    
    public NavMeshAgent navMeshAgent;


    public Transform player;

    public float speed = 10f;

    public float distanceFromTarget;
    
    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
        enemyAnimator = GetComponent<EnemyAnimator>();
    }

    private void Start()
    {

    }

    public void HandleDetectionAndMoveToTarget()
    {
        if(_enemy.isPerformingAction)
        {
            return;
        }

        if (Vector3.Distance(player.position, transform.position) <= _enemy.detectionRadius)
        {
            transform.LookAt(player);
        }
        else
        {
            enemyAnimator.anim.SetFloat("Blend", 0, 0.1f, Time.deltaTime);
        }
    }
}
