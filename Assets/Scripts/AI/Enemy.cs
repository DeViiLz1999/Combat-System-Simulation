using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Character
{
    public State currentState;

    EnemyController enemyController;
    EnemyAnimator enemyanimator;
    EnemyStats enemyStats;
    Animator anim;

    public SoundManager soundManager;

    public EnemyAttack[] enemyAttacks;
    public EnemyAttack currentAttack;

    public CharacterStats currentTarget;
    public NavMeshAgent navMeshAgent;
    public Rigidbody enemyrb;

    public bool isPerformingAction;

    public float detectionRadius = 20f;
    public float minDetectionAngle = -50f;
    public float maxDetectionAngle = 50f;
    public float viewableAngle;

    public float currentRecoveryTime = 0;

    public float distanceFromTarget;
    public float maxDistanceToAttack = 3f;

    public float rotationSpeed = 15f;

    public bool isleftHand;
    public bool isrightHand;

    private void Awake()
    {
        enemyController = GetComponent<EnemyController>();
        enemyanimator = GetComponent<EnemyAnimator>();
        enemyStats = GetComponent<EnemyStats>();
        navMeshAgent = GetComponentInChildren<NavMeshAgent>();
        enemyrb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        soundManager = GetComponent<SoundManager>();

        navMeshAgent.enabled = false;
    }

    private void Start()
    {
        enemyrb.isKinematic = false;
    }
    private void Update()
    {
        HandleRecoveryTime();
        enemyStats.Die();

        isrightHand = anim.GetBool("isRightHand");
        isleftHand = anim.GetBool("isLeftHand");
    }

    private void HandleCurrentState()
    {
        //enemyController.HandleDetectionAndMoveToTarget();

        if(currentState != null)
        {
            State nextState = currentState.Tick(this, enemyStats, enemyanimator);

            if(nextState != null)
            {
                NextState(nextState);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }

   
    private void HandleRecoveryTime()
    {
        if(currentRecoveryTime > 0)
        {
            currentRecoveryTime -= Time.deltaTime;
        }

        if(isPerformingAction)
        {
            if(currentRecoveryTime <= 0)
            {
                isPerformingAction = false;
            }
        }
    }

    private void NextState(State state)
    {
        currentState = state;
    }
    private void FixedUpdate()
    {
        HandleCurrentState();
    }
}
