using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Model
{
    [Serializable]
    public class Skill
    {
        [SerializeField] private string name;
        [SerializeField] private int level;
        [SerializeField] private KeyCode shortcut;
        

        [SerializeField] public float damage;

        public Skill(string name, KeyCode shortcut)
        {
            this.shortcut = shortcut;
            this.name = name;
        }
    }
}