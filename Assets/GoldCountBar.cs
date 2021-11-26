using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;


namespace SG
{
    public class GoldCountBar : MonoBehaviour
    {
        public Text goldCountText;
        public Text merchantGoldText;                  

       
        public void SetGoldCountText(int goldCount)
        {
            goldCountText.text = goldCount.ToString();
            merchantGoldText.text = goldCount.ToString();
        }          
    }
}
