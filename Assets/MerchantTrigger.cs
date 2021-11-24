using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MerchantTrigger : MonoBehaviour
{

    public bool nearMerchant = false;
    public GameObject MerchantMenuUI;
    public GameObject playerUI;
    public GameObject InteractProp;

    private void Update()
    {
        if (Keyboard.current.fKey.wasReleasedThisFrame)
        {
            if (nearMerchant == true)
            {
                MerchantMenuUI.SetActive(true);
                InteractProp.SetActive(false);
                playerUI.SetActive(false);
                Time.timeScale = 0.1f;
                Cursor.visible = true;
            }
        }        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            nearMerchant = true;
            //Debug.Log("Gracz blisko kupca");
            InteractProp.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            nearMerchant = false;
            //Debug.Log("Gracz odszedł od kupca");
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
}
