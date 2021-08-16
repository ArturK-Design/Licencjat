using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SG
{
    public class HealthBar : MonoBehaviour
    {
        public Slider slider;

        public void SetMaxHealth(int maxHelth)
        {
            slider.maxValue = maxHelth;
            slider.value = maxHelth;
        }

        public void SetCurrentHealth(int currentHealt)
        {
            slider.value = currentHealt;
        }

    }
}
