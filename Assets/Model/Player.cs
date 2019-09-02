using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Model
{
    [Serializable]
    public class Player
    {
        
        public float maxHealth;
        
        public Class currentClass;
        
        [SerializeField]
        private Weapon currentWeapon;
        
        [SerializeField]
        public Dictionary<Armour, Armour.Slots> currentArmour;
        
        [SerializeField]
        public int unusedAttributes;

        public Player(float maxHealth, Class currentClass)
        {
            this.maxHealth = maxHealth;
            this.currentClass = currentClass;
        }
        
        
        public void Attack()
        {

        }

        public void UseSkill(string shortcut)
        {
            
        }

        public void EquipArmour(Armour item)
        {
            
        }
        
        public void EquipWeapon(Weapon weapon)
        {
            
        }

        public void RemoveWeapon(Weapon weapon)
        {
            
        }

        public void RemoveArmour(Armour.Slots slot)
        {
            
        }
    }
}