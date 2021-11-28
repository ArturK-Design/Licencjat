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
        public GameObject GateLeft;
        public GameObject GateRight;

        public void Start()
        {
            GateLeft.GetComponent<Animator>().enabled = true;
            GateRight.GetComponent<Animator>().enabled = true;
            GateLeft.GetComponent<Animator>().Play("FenceLeftOpen");
            GateRight.GetComponent<Animator>().Play("FenceRightOpen");
            //GateLeft.GetComponent<Animator>().enabled = false;
            //GateRight.GetComponent<Animator>().enabled = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player" && Stage2 == true)
            {
                Stage2Blocker.SetActive(true);
                Merchant.transform.position = new Vector3(-15.821f, 9.897f, 78.08f);
                EnemyManagerStage1.SetActive(false);
                EnemyManagerStage2.SetActive(true);
                //MerchantActivator.GetComponent<MerchantTrigger>().Stage2Enter();
            }
            else
            {
                if (other.tag == "Player" && Stage3 == true)
                {
                    Stage3Blocker.SetActive(true);
                    EnemyManagerStage2.SetActive(false);
                    EnemyManagerStage3.SetActive(true);
                }
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.tag == "Player" && Stage2 == true)
            {
                MerchantActivator.GetComponent<MerchantTrigger>().Stage2Enter();
            }
            else
            {
                if (other.tag == "Player" && Stage3 == true)
                {
                    MerchantActivator.GetComponent<MerchantTrigger>().Stage3Enter();
                    MerchantActivator.GetComponent<MerchantTrigger>().BossEntered();                  
                    
                }
            }
            GateLeft.GetComponent<Animator>().enabled = true;
            GateRight.GetComponent<Animator>().enabled = true;
            GateLeft.GetComponent<Animator>().Play("FenceRightClose");
            GateRight.GetComponent<Animator>().Play("FenceLeftClose");

        }


    }
}
