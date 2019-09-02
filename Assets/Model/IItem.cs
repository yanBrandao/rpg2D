using UnityEngine;

namespace Model
{
    public interface IItem
    {
        [SerializeField]
        string Name { get; set; }
    }
}