using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Model
{
    [Serializable]
    public class Armour : IItem
    {
        public enum Slots {Head, Shoulder, Chest, Legs, Boots, Necklace, LeftRing, RightRing, Bracelet, Gloves, Belt, Eyes, Nose, Mouth}
        [SerializeField]
        public string Name { get; set; }
        [FormerlySerializedAs("Position")] [SerializeField]
        public Slots position;
    }
}