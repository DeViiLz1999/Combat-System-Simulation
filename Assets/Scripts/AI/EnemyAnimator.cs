using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    Enemy m_Enemy;

    public Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        m_Enemy = GetComponent<Enemy>();
    }
    public void PlayTargetAnimation(string targetAnimation, bool isInteracting)
    {
        anim.applyRootMotion = isInteracting;
        anim.SetBool("isInteracting", isInteracting);
        anim.CrossFade(targetAnimation, 0.2f);
    }

    private void OnEnemyMove()
    {   
        float delta = Time.deltaTime;
        m_Enemy.enemyrb.drag = 0;

        Vector3 deltaPosition = anim.deltaPosition;
        deltaPosition.y = 0;

        Vector3 velocity = deltaPosition / delta;
        m_Enemy.enemyrb.velocity = velocity;
    }
}
