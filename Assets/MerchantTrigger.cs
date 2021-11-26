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

        public bool nearMerchant = false;
        public GameObject MerchantMenuUI;
        public GameObject playerUI;
        public GameObject InteractProp;
        public GameObject dmgBuy;
        public GameObject healBuy;
        public GameObject maxHealthBuy;
        public GameObject keyBuy;
        private Button dmgButton;
        private Button healButton;
        private Button maxHealthButton;
        private Button keyButton;
        public GameObject player;
        public Text goldCountText;
        public Text merchantGoldText;
        private int moneyCount;        
        public int price;

        public void Start()
        {            
            dmgButton = dmgBuy.GetComponent<Button>();
            maxHealthButton = maxHealthBuy.GetComponent<Button>();
            healButton = healBuy.GetComponent<Button>();
            keyButton = keyBuy.GetComponent<Button>();
            moneyCount = player.GetComponent<PlayerStats>().goldCount;       
            
        }
        private void Update()
        {

            if (Keyboard.current.fKey.wasReleasedThisFrame)
            {
                UpdateMoney();
                MerchantOpen();
            }            
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
            Debug.Log(moneyCount + "posiada gracz w momencie włączenia sklepu");
        }
        public void UpdateGoldBar()
        {
            goldCountText.text = moneyCount.ToString();
            merchantGoldText.text = moneyCount.ToString();
        }
        

    }
}
