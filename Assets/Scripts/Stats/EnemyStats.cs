using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    AnimatorManager manager;
    Animator animator;

    public bool isDestroy;

    private void Awake()
    {
        manager = GetComponent<AnimatorManager>();
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
        maxHealth = SetMaxHealthFromHealthlevel();
        currentHealth = maxHealth;
        isDead = false;
        isDestroy = false;
    }

    private int SetMaxHealthFromHealthlevel()
    {
        maxHealth = healthLevel * 10;
        return maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (isDead == true)
        {
            return;
        }

        currentHealth -= damage;


        animator.Play("Damage2");

        if (currentHealth <= 0)
        {
            ScoringManager.score += 1;
            currentHealth = 0;
            animator.Play("Dead2");
            isDead = true;
        }
    }

    public void Die()
    {
        if(isDead == true)
        {
            isDestroy = true;
            Destroy(gameObject, 2.5f);
        }
    }
}
