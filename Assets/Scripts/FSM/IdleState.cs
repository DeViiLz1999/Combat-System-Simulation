using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    public PursueState pursueState;

    public LayerMask detectionLayer;

    public override State Tick(Enemy enemy, EnemyStats enemyStats, EnemyAnimator enemyAnimator)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, enemy.detectionRadius, detectionLayer);

        for (int i = 0; i < colliders.Length; i++)
        {
            CharacterStats characterStats = colliders[i].transform.GetComponent<CharacterStats>();

            if (characterStats != null)
            {
                Vector3 targetDirection = characterStats.transform.position - transform.position;
                float viewingAngle = Vector3.Angle(targetDirection, transform.forward);

                if (viewingAngle > enemy.minDetectionAngle && viewingAngle < enemy.maxDetectionAngle)
                {
                    enemy.currentTarget = characterStats;
                }
            }
        }

        if(enemy.currentTarget != null)
        {
            return pursueState;
        }
        else
        {
            return this;
        }
        
    }
}
