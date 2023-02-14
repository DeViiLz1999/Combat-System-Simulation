using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    public Health healthbar;

    AnimatorManager manager;
    InputManager inputManager;
    Player player;


    private void Awake()
    {
        manager = GetComponent<AnimatorManager>();
        inputManager = GetComponent<InputManager>();
        player = GetComponent<Player>();
        isDead = false;
    }
    private void Start()
    {
        maxHealth = SetMaxHealthFromHealthlevel();
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth); // Sets max value of the healthbar to the player's health
    }

    public int SetMaxHealthFromHealthlevel()
    {
        maxHealth = healthLevel * 10;
        return maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if(player.isInvulerable)
        {
            return;
        }

        if(isDead == true)
        {
            return;
        }
        currentHealth -= damage;

        healthbar.SetCurrentHealth(currentHealth); // if damage change current health and pass to the player's health

        manager.PlayTargetAnimation("Damage1", true);

        if(currentHealth <= 0)
        {
            currentHealth = 0;
            manager.PlayTargetAnimation("Dead1", true);
            isDead = true;
        }
    }

    public void HealPlayer(int healAmount)
    {
        currentHealth = currentHealth + healAmount;

        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        healthbar.SetCurrentHealth(currentHealth);
    }

}
