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
            if (other.tag == "Player" && hasKey == false)
            {
                StageBlockerNoKey.SetActive(true);
            }
            if( other.tag == "Player" && hasKey == true)
            {
                leftGate.GetComponent<Animator>().enabled = true;
                rightGate.GetComponent<Animator>().enabled = true;
                leftGate.GetComponent<Animator>().Play("FenceLeftOpen");
                rightGate.GetComponent<Animator>().Play("FenceRightOpen");
                var main = ps.main;
                main.loop = false;
                skull.GetComponent<Animator>().Play("SkullShrink");
            }

        }

        private void OnTriggerExit(Collider other)
        {
            CheckKey();
            if (other.tag == "Player" && hasKey == false)
            {
                StageBlockerNoKey.SetActive(false);
            }
        }

        

    }
}
