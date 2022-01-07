using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SG
{
    public class PlayerStats : CharacterStats
    {
        HealthBar healthBar;
        StaminaBar staminaBar;
        AnimatorHandler animatorHandler;
        public GameObject DeathScreen;
                     

        private void Awake()
        {
            healthBar = FindObjectOfType<HealthBar>();
            staminaBar = FindObjectOfType<StaminaBar>();
            animatorHandler = GetComponentInChildren<AnimatorHandler>();            
        }

        void Start()
        {
            maxHealth = SetMaxHealthFromHealthLevel();
            currentHealth = maxHealth;
            healthBar.SetMaxHealth(maxHealth);
            healthBar.SetCurrentHealth(currentHealth);
            
            maxStamina = SetMaxStaminaFromStaminaLevel();
            currentStamina = maxStamina;
            //staminaBar.SetMaxStamina(maxStamina);
            staminaBar.SetCurrentStamina(currentStamina);
        }
                
        private int SetMaxHealthFromHealthLevel()
        {
            maxHealth = healthLevel * 10;
            return maxHealth;
        }

        private int SetMaxStaminaFromStaminaLevel()
        {
            maxStamina = staminaLevel * 10;
            return maxStamina;
        }

        public void TakeDamage(int damage)
        {
            if (isDead)
                return;
            currentHealth = currentHealth - damage;
            healthBar.SetCurrentHealth(currentHealth);

            animatorHandler.PlayTargetAnimation("Damage_01", true);

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                animatorHandler.PlayTargetAnimation("Dead_01", true);
                isDead = true;
                DeathScreen.SetActive(true);
                DeathScreen.GetComponent<Animator>().enabled = true;
                DeathScreen.GetComponent<Animator>().Play("FinalScreenFadeIn");
                Cursor.visible = true;
                //HANDLE PLAYER DEATH
            }
        }

        public void TakeStaminaDamage(int damage)
        {
            currentStamina = currentStamina - damage;
            staminaBar.SetCurrentStamina(currentStamina);
        }

        public void AddGold(int gold)
        {
            goldCount = goldCount + gold;
        }

        public void Heal()
        {
            if (goldCount >= 50)
            {
                currentHealth = maxHealth;
                goldCount = goldCount - 50;
                healthBar.SetMaxHealth(maxHealth);
                healthBar.SetCurrentHealth(currentHealth);
                //Debug.Log(maxHealth);
                //Debug.Log(goldCount);
                //Debug.Log("Wykonano akcję leczenia");
            }
            else
            {
                //Debug.Log("Za mało hajsu");
            }
        }

        public void healAlways()
        {
            currentHealth = maxHealth;
            healthBar.SetMaxHealth(maxHealth);
            healthBar.SetCurrentHealth(currentHealth);
            Debug.Log("wyleczono mimo że kupiłeś heala na końcu");
        }

        public void maxHealthUp()
        {
            if (goldCount >= 50)
            {
                healthLevel = healthLevel + 1;
                SetMaxHealthFromHealthLevel();
                goldCount = goldCount - 50;
                healthBar.SetMaxHealth(maxHealth);
                healthBar.SetCurrentHealth(currentHealth);
                //Debug.Log("Dodano maxymalne żyćko" + "a hajsu został" + goldCount);
            }
            else
            {
                //Debug.Log("Za mało hajsu");
            }
        }

        public void DmgUpBuy()
        {
            goldCount = goldCount - 50;
        }
    }
}