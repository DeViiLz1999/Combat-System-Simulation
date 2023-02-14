using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PursueState : State
{
    public CombatState combatState;
    public override State Tick(Enemy enemy, EnemyStats enemyStats, EnemyAnimator enemyAnimator)
    {
        if(enemy.isPerformingAction)
        {
            enemyAnimator.anim.SetFloat("Blend", 0, 0.1f, Time.deltaTime);
            return this;
        }

        Vector3 targetDirection = enemy.currentTarget.transform.position - enemy.transform.position;
         enemy.distanceFromTarget = Vector3.Distance(enemy.currentTarget.transform.position, enemy.transform.position);
        float viewingAngle = Vector3.Angle(targetDirection, enemy.transform.forward);

        if (enemy.distanceFromTarget > enemy.maxDistanceToAttack)
        {
            enemyAnimator.anim.SetFloat("Blend", 1, 0.1f, Time.deltaTime);
        }

        HandleRotation(enemy);

        if(enemy.distanceFromTarget <= enemy.maxDistanceToAttack)
        {
            return combatState;
        }
        else
        {
            return this;
        }
        
    }

    private void HandleRotation(Enemy enemy)
    {
        if (enemy.isPerformingAction)
        {
            Vector3 direction = enemy.currentTarget.transform.position - transform.position;
            direction.y = 0;
            direction.Normalize();

            if (direction == Vector3.zero)
            {
                direction = transform.forward;
            }

            Quaternion targetRotation = Quaternion.LookRotation(direction);
            enemy.transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, enemy.rotationSpeed / Time.deltaTime);
        }

        else
        {
            Vector3 relativeDirection = transform.InverseTransformDirection(enemy.navMeshAgent.desiredVelocity);
            Vector3 targetVelocity = enemy.enemyrb.velocity;

            enemy.navMeshAgent.enabled = true;
            enemy.navMeshAgent.SetDestination(enemy.currentTarget.transform.position);
            enemy.enemyrb.velocity = targetVelocity;
            enemy.transform.rotation = Quaternion.Slerp(enemy.transform.rotation, enemy.navMeshAgent.transform.rotation, enemy.rotationSpeed / Time.deltaTime);
        }
    }
}
