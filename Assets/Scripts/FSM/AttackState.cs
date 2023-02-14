using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    public EnemyAttack[] enemyAttacks;
    public EnemyAttack currentAttack;

    public CombatState combatState;
    public IdleState idleState;
    public override State Tick(Enemy enemy, EnemyStats enemyStats, EnemyAnimator enemyAnimator)
    {
        if(enemyStats.isDead == true)
        {
            return idleState;
        }

        Vector3 targetDirection = enemy.currentTarget.transform.position - transform.position;
        enemy.viewableAngle = Vector3.Angle(targetDirection, transform.forward);

        if (enemy.isPerformingAction)
        {
            return combatState;
        }


        if(currentAttack != null)
        {
            if(enemy.distanceFromTarget < currentAttack.minDistanceNeededToAttack)
            {
                return this;
            }
            else if(enemy.distanceFromTarget < currentAttack.maxDistanceNeededToAttack)
            {
                if(enemy.viewableAngle <= currentAttack.maxAttackAngle 
                    && enemy.viewableAngle >= currentAttack.minAttackAngle)
                {
                    if(enemy.currentRecoveryTime <=0 && enemy.isPerformingAction == false)
                    {
                        enemyAnimator.anim.SetFloat("Blend", 0, 0.1f, Time.deltaTime);
                        enemyAnimator.PlayTargetAnimation(currentAttack.actionAnimation, true);
                        enemy.isPerformingAction = true;
                        enemy.currentRecoveryTime = currentAttack.recoveryTime;
                        currentAttack = null;
                        return combatState;
                    }
                }
            }
        }
        else
        {
            GetAttack(enemy);
        }

        return combatState;
    }

    private void GetAttack(Enemy enemy)

    {
        Vector3 targetDirection = enemy.currentTarget.transform.position - transform.position;
        float viewAngle = Vector3.Angle(targetDirection, transform.position);

        enemy.distanceFromTarget = Vector3.Distance(enemy.currentTarget.transform.position, transform.position);

        int maxScore = 0;

        for (int i = 0; i < enemyAttacks.Length; i++)
        {
            EnemyAttack enemyAttack = enemyAttacks[i];

            if (enemy.distanceFromTarget <= enemyAttack.maxDistanceNeededToAttack
                && enemy.distanceFromTarget >= enemyAttack.minDistanceNeededToAttack)
            {
                if (viewAngle <= enemyAttack.maxAttackAngle
                    && viewAngle >= enemyAttack.minAttackAngle)
                {
                    maxScore += enemyAttack.attackScore;
                }
            }
        }

        int randomValue = Random.Range(0, maxScore);
        int tempScore = 0;

        for (int i = 0; i < enemyAttacks.Length; i++)
        {
            EnemyAttack enemyAttack = enemyAttacks[i];

            if (enemy.distanceFromTarget <= enemyAttack.maxDistanceNeededToAttack
                && enemy.distanceFromTarget >= enemyAttack.minDistanceNeededToAttack)
            {
                if (viewAngle <= enemyAttack.maxAttackAngle
                    && viewAngle >= enemyAttack.minAttackAngle)
                {
                    if (currentAttack != null)
                    {
                        return;
                    }

                    tempScore = enemyAttack.attackScore;

                    if (tempScore > randomValue)
                    {
                        currentAttack = enemyAttack;
                    }
                }
            }
        }
    }
}
