using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG {
    public class StageBlocker : MonoBehaviour
    {
        public GameObject StageBlockerNoKey;
        public GameObject MerchantActivator;
        public GameObject leftGate;
        public GameObject rightGate;
        public GameObject fire;
        public GameObject skull;
        private bool hasKey;
        private ParticleSystem ps;
        public bool bossDefeated = false;
        public GameObject endGameBlocker;
        public bool lastGate = false;
        public GameObject noBoss;
        

        public void Awake()
        {
            hasKey = MerchantActivator.GetComponent<MerchantTrigger>().keyBought;
            ps = fire.GetComponent<ParticleSystem>();           
            
        }
               
        public void CheckKey()
        {
            hasKey = MerchantActivator.GetComponent<MerchantTrigger>().keyBought;
        }

        private void OnTriggerEnter(Collider other)
        {
            CheckKey();
            if (other.tag == "Player" && hasKey == false && lastGate != true)
            {
                StageBlockerNoKey.SetActive(true);
            }
            else
            {
                if (lastGate == true && bossDefeated != true)
                {
                    noBoss.SetActive(true);
                }
            }
            if( other.tag == "Player" && hasKey == true && lastGate != true)
            {
                leftGate.GetComponent<Animator>().enabled = true;
                rightGate.GetComponent<Animator>().enabled = true;
                leftGate.GetComponent<Animator>().Play("FenceLeftOpen");
                rightGate.GetComponent<Animator>().Play("FenceRightOpen");
                var main = ps.main;
                main.loop = false;
                skull.GetComponent<Animator>().Play("SkullShrink");
            }

            if (other.tag == "Player" && bossDefeated == true)
            {
                leftGate.GetComponent<Animator>().enabled = true;
                rightGate.GetComponent<Animator>().enabled = true;
                leftGate.GetComponent<Animator>().Play("FenceLeftOpen");
                rightGate.GetComponent<Animator>().Play("FenceRightOpen");
                var main = ps.main;
                main.loop = false;
                skull.GetComponent<Animator>().Play("SkullShrink");
                endGameBlocker.SetActive(false);
            }
                       
        }

        private void OnTriggerExit(Collider other)
        {
            CheckKey();
            if (other.tag == "Player" && hasKey == false && lastGate != true)
            {
                StageBlockerNoKey.SetActive(false);
            }
            else
            {
                if (other.tag == "Player" && bossDefeated != true)
                {
                    noBoss.SetActive(false);
                }
            }
        }               

        public void UnlockFinalGate()
        {
            bossDefeated = true;
            //Debug.Log("Dostałem info o odblokowaniu bramy");
        }
    }
}
