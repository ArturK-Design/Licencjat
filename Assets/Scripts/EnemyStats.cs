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

            animator.Play("Damage_01");

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                animator.Play("Dead_01");
                isDead = true;
                StartCoroutine(deadTime());
                
                //HANDLE PLAYER DEATH
            }
        }

        IEnumerator deadTime()
        {
            
            yield return new WaitForSeconds(3);
            this.gameObject.SetActive(false);
        }
    }
}

