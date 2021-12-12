using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.UI;


namespace SG
{
    public class MerchantTrigger : MonoBehaviour
    {

        private bool nearMerchant = false;
        public GameObject MerchantMenuUI;
        public GameObject playerUI;
        public GameObject InteractProp;
        public GameObject dmgBuy;
        public GameObject healBuy;
        public GameObject maxHealthBuy;
        public GameObject keyBuy;
        public GameObject QuestTitle;
        public GameObject ProgressToGate;
        public GameObject ReturnToMerchant;
        private Button dmgButton;
        private Button healButton;
        private Button maxHealthButton;
        private Button keyButton;
        public GameObject player;
        public Text goldCountText;
        public Text merchantGoldText;
        private int moneyCount;        
        public int price;
        public string enemies;
        private string enemiesLeft;
        public GameObject enemyManagerStage1;
        public GameObject enemyManagerStage2;
        public GameObject enemyManagerStage3;
        public bool keyBought = false;
        public GameObject stage2Blocker;
        public GameObject stage3Blocker;
        private bool stage2Unlocked = false;
        private bool stage3Unlocked = false;
        public GameObject bossTitle;
        public GameObject progressToEnd;
        public bool enteredBossArena = false;
        public GameObject lastGate;
        public GameObject StartScreenUI;
        public GameObject maxEnemiesOnStage;

        public void Start()
        {            
            dmgButton = dmgBuy.GetComponent<Button>();
            maxHealthButton = maxHealthBuy.GetComponent<Button>();
            healButton = healBuy.GetComponent<Button>();
            keyButton = keyBuy.GetComponent<Button>();
            moneyCount = player.GetComponent<PlayerStats>().goldCount;
            maxEnemiesOnStage.GetComponent<Text>().text = "10";
            //string text = enemyManagerStage1.GetComponent<EnemyCount>().enemyCount.text;
            //enemies = text.ToString();
            //stage2Blocker = GameObject.FindGameObjectWithTag("Stage2Blocker");
            //stage3Blocker = GameObject.FindGameObjectWithTag("Stage3Blocker");
            //StartScreen();

        }
        private void Update()
        {
            
            if (Keyboard.current.fKey.wasReleasedThisFrame)
            {
                UpdateMoney();
                MerchantOpen();
            }
            countEnemies();
            
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                nearMerchant = true;
                InteractProp.SetActive(true);                
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.tag == "Player")
            {
                nearMerchant = false;
                InteractProp.SetActive(false);                
            }
        }

        public void MerchantClose()
        {
            MerchantMenuUI.SetActive(false);
            InteractProp.SetActive(true);
            playerUI.SetActive(true);
            Time.timeScale = 1f;
            Cursor.visible = false;
        }
        public void MerchantOpen()
        {
            if (nearMerchant == true)
            {

                MerchantMenuUI.SetActive(true);
                InteractProp.SetActive(false);
                playerUI.SetActive(false);
                Time.timeScale = 0.1f;
                Cursor.visible = true;
                DisableButtons();
                StartScreenUI.SetActive(false);
            }
        }

        public void DisableButtons()
        {
            if (moneyCount >= price)
            {
                healButton.interactable = true;
                maxHealthButton.interactable = true;
                dmgButton.interactable = true;
            }
            else
            {
              maxHealthButton.interactable = false;
              healButton.interactable = false;
              dmgButton.interactable = false;
            }
            if (enemies == "0" && keyBought != true)
            {
                keyButton.interactable = true;
                //QuestTitle.SetActive(false);
                //ReturnToMerchant.SetActive(true);
            }
            else
            {
                keyButton.interactable = false;
            }
        }
        public void DetractGold(int goldCount)
        {
            moneyCount = moneyCount - price; 
            goldCount = moneyCount;
            DisableButtons();
            UpdateGoldBar();
        }
        public void UpdateMoney()
        {
            moneyCount = GameObject.Find("Player").GetComponent<PlayerStats>().goldCount;
            //Debug.Log(moneyCount + "posiada gracz w momencie włączenia sklepu");
        }
        public void UpdateGoldBar()
        {
            goldCountText.text = moneyCount.ToString();
            merchantGoldText.text = moneyCount.ToString();
        }
        public void countEnemies()
        {
            if (enemyManagerStage1.activeInHierarchy == true)
            {
                string text = enemyManagerStage1.GetComponent<EnemyCount>().enemyCount.text;
                enemies = text.ToString();
                //Debug.Log(enemies + " tylu wrogów zostało w 1 levelu");
                if (enemies == "0" && keyBought == false)
                {
                    QuestTitle.SetActive(false);
                    ReturnToMerchant.SetActive(true);
                }
            }
            else 
            {
                if(enemyManagerStage2.activeInHierarchy == true)
                {
                    string text = enemyManagerStage2.GetComponent<EnemyCount>().enemyCount.text;
                    enemies = text.ToString();
                    //Debug.Log(enemies + " tylu wrogów zostało w 2 levelu");
                }
                if (enemies == "0" && keyBought == false)
                {
                    QuestTitle.SetActive(false);
                    ReturnToMerchant.SetActive(true);
                }              
            }

            if (enemyManagerStage3.activeInHierarchy == true && enteredBossArena == true)
            {
                string text = enemyManagerStage3.GetComponent<EnemyCount>().enemyCount.text;
                enemies = text.ToString();
                Debug.Log(enemies + " tylu wrogów zostało w 3 levelu");
                if (enemies == "0")
                {
                    QuestTitle.SetActive(false);
                    bossTitle.SetActive(false);
                    progressToEnd.SetActive(true);
                    FinalGate();

                }
            }
            else
                return;


            if (keyBought == true && enemies != "0")
            {
                keyButton.interactable = false;                
            }

        }
        public void UnlockNextLevel()
        {
            keyButton.interactable = false;
            keyBought = true;
            if(stage2Unlocked == false && stage3Unlocked == false)
            {
                stage2Blocker.SetActive(false);
                stage2Unlocked = true;
                ReturnToMerchant.SetActive(false);
                ProgressToGate.SetActive(true);
            }
            else
            {
                if (stage2Unlocked == true && stage3Unlocked == false)
                {
                    stage3Blocker.SetActive(false);
                    stage3Unlocked = true;                    
                    ProgressToGate.SetActive(true);
                    ReturnToMerchant.SetActive(false);
                }
            }
        }        

        public void DmgUp()
        {
            DamageCollider damageCollider = player.GetComponentInChildren<DamageCollider>();
            damageCollider.currentWeaponDamage += damageCollider.dmgup;

        }

        public void Stage2Enter()
        {
            keyBought = false;
            ProgressToGate.SetActive(false);
            QuestTitle.SetActive(true);
            
        }

        public void Stage3Enter()
        {
            //keyBought = false;
            bossTitle.SetActive(true);
            ProgressToGate.SetActive(false);
        }
        
        public void BossEntered()
        {
            enteredBossArena = true;
        }

        public void FinalGate()
        {
            StageBlocker stageblocker = lastGate.GetComponent<StageBlocker>();
            stageblocker.UnlockFinalGate();
            Debug.Log("brama odblokowana");
        }

        private void StartScreen()
        {
            //StartScreen.SetActive(true);
            playerUI.SetActive(false);
            StartScreenUI.GetComponent<Animator>().enabled = true;
            StartScreenUI.GetComponent<Animator>().Play("StartFadeOut");
            StartScreenUI.SetActive(false);
            Cursor.visible = true;
        }

    }
}
