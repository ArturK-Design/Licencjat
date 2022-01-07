using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SG
{
    public class EnemyStats : CharacterStats
    {
        Animator animator;
        public Text enemyCount;
        
        public int goldAwardedOnDeatch;

        private void Awake()
        {
            animator = GetComponentInChildren<Animator>();
            enemyCount = GameObject.Find("PlayerUI/EnemyCount").GetComponent<Text>();           
        }

        void Start()
        {
            maxHealth = SetMaxHealthFromHealthLevel();
            currentHealth = maxHealth;
            
        }

        private int SetMaxHealthFromHealthLevel()
        {
            maxHealth = healthLevel * 10;
            return maxHealth;
        }

        public void TakeDamage(int damage)
        {
            if (isDead)
                return;
            currentHealth = currentHealth - damage;
            //Debug.Log(damage);

            animator.Play("Damage_01");

            if (currentHealth <= 0)
            {
                HandleDeath();
                //HANDLE PLAYER DEATH
            }
        }

        public void HandleDeath()
        {
            currentHealth = 0;
            animator.Play("Dead_01");
            isDead = true;
            PlayerStats playerStats = FindObjectOfType<PlayerStats>();
            GoldCountBar goldCountBar = FindObjectOfType<GoldCountBar>();

            if(playerStats != null)
            {
                playerStats.AddGold(goldAwardedOnDeatch);

                if(goldCountBar != null)
                {
                    goldCountBar.SetGoldCountText(playerStats.goldCount);
                }
            }
            StartCoroutine(deadTime());
            InputHandler inputhandler = FindObjectOfType<InputHandler>();
            inputhandler.ClearLockOn();

        }

        IEnumerator deadTime()
        {
            
            yield return new WaitForSeconds(2);
            //Debug.Log("dead");
            this.gameObject.SetActive(false);
        }
    }
}

