using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG
{
    public class CharacterStats : MonoBehaviour
    {
        public int healthLevel = 10;
        public int maxHealth;
        public int currentHealth;
        public bool godMod;

        public int staminaLevel = 10;
        public int maxStamina;
        public int currentStamina;
    }
}
