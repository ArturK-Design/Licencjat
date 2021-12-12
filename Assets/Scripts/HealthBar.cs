using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SG
{
    public class HealthBar : MonoBehaviour
    {
        public Slider slider;
        public GameObject maxHpNumber;
        public GameObject currentHpNumber;
        //private string maxHP;
        //private string currHP;

        public void Awake()
        {
           
            //currHP = currentHpNumber.GetComponent<Text>().text;
        }

        public void SetMaxHealth(int maxHelth)
        {
            slider.maxValue = maxHelth;
            slider.value = maxHelth;
            maxHpNumber.GetComponent<Text>().text = maxHelth.ToString();
            //maxHP = maxHelth.ToString();
        }

        public void SetCurrentHealth(int currentHealt)
        {
            slider.value = currentHealt;
            currentHpNumber.GetComponent<Text>().text = currentHealt.ToString();
            //currHP = currentHealt.ToString();

        }
        //public void MaxHpBuyUpdate(int maxHelth)
        //{
          //  maxHpNumber.GetComponent<Text>().text = maxHelth.ToString();            
        //}

    }
}
