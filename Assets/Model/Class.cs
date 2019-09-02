using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Model
{

    [Serializable]
    public class Class
    {
        public enum ClassType { Mage, Warrior, Archer}

        [SerializeField] public List<Skill> skills;
        [SerializeField] public ClassType type;

        public Class(ClassType type)
        {
            this.type = type;
            if (type == ClassType.Mage)
                skills = new List<Skill> { new Skill("Fireball", KeyCode.Z), new Skill("IceShot", KeyCode.X)};
            else if (type == ClassType.Archer)
                skills = new List<Skill> {new Skill("Double Shot", KeyCode.Z)};
            else if (type == ClassType.Warrior)
                skills = new List<Skill> {new Skill("Bash!", KeyCode.Z)};
        }
    }
}