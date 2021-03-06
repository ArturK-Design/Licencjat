using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG
{
    public class DamageCollider : MonoBehaviour
    {
        public Collider damageCollider;

        public int currentWeaponDamage = 25;
        public int dmgup = 5;

        private void Awake()
        {
            damageCollider = GetComponent<Collider>();
            damageCollider.gameObject.SetActive(true);
            damageCollider.isTrigger = true;
            damageCollider.enabled = false;
        }



        public void EnableDamageCollider()
        {
            damageCollider.enabled = true;
        }

        public void DisableDamageCollider()
        {
            damageCollider.enabled = false;
        }

        private void OnTriggerEnter(Collider collision)
        {
            if(collision.tag == "Player")
            {
                PlayerStats playerStats = collision.GetComponent<PlayerStats>();
                

                if(playerStats != null)
                {
                    playerStats.TakeDamage(currentWeaponDamage);
                }
                
            }

            if(collision.gameObject.CompareTag("Enemy"))
            {
                EnemyStats enemyStats = collision.GetComponent<EnemyStats>();

                if(enemyStats != null)
                {
                    enemyStats.TakeDamage(currentWeaponDamage);
                }
            }
        }
        public void DmgUp()
        {
            currentWeaponDamage = currentWeaponDamage + dmgup;
            Debug.Log(currentWeaponDamage);
        }
    }
}
