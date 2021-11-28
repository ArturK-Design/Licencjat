using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG
{
    public class ReturnBlocker : MonoBehaviour
    {

        public bool Stage2;
        public bool Stage3;
        public GameObject Stage2Blocker;
        public GameObject Stage3Blocker;
        public GameObject Merchant;
        public GameObject MerchantActivator;
        public GameObject EnemyManagerStage1;
        public GameObject EnemyManagerStage2;
        public GameObject EnemyManagerStage3;       

       
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player" && Stage2 == true)
            {
                Stage2Blocker.SetActive(true);
                Merchant.transform.position = new Vector3(-15.821f, 9.897f, 78.08f);
                EnemyManagerStage1.SetActive(false);
                EnemyManagerStage2.SetActive(true);
                MerchantActivator.GetComponent<MerchantTrigger>().Stage2Enter();


            }
            else
            {
                if (other.tag == "Player" && Stage3 == true)
                {
                    Stage3Blocker.SetActive(true);
                    EnemyManagerStage2.SetActive(false);
                }
            }
        }


    }
}
