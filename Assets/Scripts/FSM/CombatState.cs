using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatState : State
{
    public AttackState attackState;
    public PursueState pursueState;
    public override State Tick(Enemy enemy, EnemyStats enemyStats, EnemyAnimator enemyAnimator)
    {
        enemy.distanceFromTarget = Vector3.Distance(enemy.currentTarget.transform.position, enemy.transform.position);

        if(enemy.isPerformingAction)
        {
            enemyAnimator.anim.SetFloat("Blend", 0, 0.1f, Time.deltaTime);
        }

        if(enemy.currentRecoveryTime <= 0 && enemy.distanceFromTarget <= enemy.maxDistanceToAttack)
        {
            return attackState;
        }
        else if(enemy.distanceFromTarget > enemy.maxDistanceToAttack)
        {
            return pursueState;
        }
        else
        {
            return this;
        }

    }
}
