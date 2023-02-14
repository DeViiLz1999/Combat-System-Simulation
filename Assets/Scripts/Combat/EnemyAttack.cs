using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "A.I/Attack Action")]
public class EnemyAttack : EnemyAction
{
    public int attackScore = 3;
    public float recoveryTime = 2f;

    public float minAttackAngle = -35f;
    public float maxAttackAngle = 35f;

    public float minDistanceNeededToAttack = 0f;
    public float maxDistanceNeededToAttack = 5;
}
