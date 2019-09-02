using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Model
{
    [Serializable]
    public class Weapon : IItem
    {
        [SerializeField]
        public float attackDamage;

        [SerializeField]
        public string Name { get; set; }
    }
}