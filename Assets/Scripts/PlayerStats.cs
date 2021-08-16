using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG
{
    public class PlayerStats : CharacterStats
    {

        public HealthBar healthBar;
        public StaminaBar staminaBar;

        AnimatorHandler animatorHandler;

        private void Awake()
        {
            healthBar = FindObjectOfType<HealthBar>();
            staminaBar = FindObjectOfType<StaminaBar>();
            animatorHandler = GetComponentInChildren<AnimatorHandler>();
        }

        private void Start()
        {
            maxHealth = SetMaxHealthFromHealthLevel();
            currentHealth = maxHealth;
            healthBar.SetMaxHealth(maxHealth);

            maxStamina = SetMaxStaminaFromStaminahLevel();
            currentStamina = maxStamina;
            staminaBar.SetMaxStamina(maxStamina);
        }

        private int SetMaxHealthFromHealthLevel()
        {
            maxHealth = healthLevel * 10;

            return maxHealth;
        }

        private int SetMaxStaminaFromStaminahLevel()
        {
            maxStamina= staminaLevel * 10;

            return maxStamina;
        }

        public void TakeDamage(int damage)
        {
            if (godMod)
                return;

            currentHealth = currentHealth - damage;
            Debug.Log(currentHealth);

            healthBar.SetCurrentHealth(currentHealth);

            animatorHandler.PlayTargetAnimation("Damage_01", true);

            if(currentHealth <= 0)
            {
                animatorHandler.PlayTargetAnimation("Dead_01", true);
            }
        }

        public void TakeStaminaDamage(int damage)
        {
            currentStamina = currentStamina - damage;
            //Debug.Log(currentStamina);
            staminaBar.SetCurrentStamina(currentStamina);
        }
    }
}
