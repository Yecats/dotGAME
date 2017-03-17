using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Items
{
    [CreateAssetMenu(menuName = "Item/Weapon", fileName = "Weapon Name")]
    public class Weapon : Item
    {
        [Header("Weapon Properties"), Tooltip("Slot that the weapon can be equiped on.")]
        public Types ItemType;
        [Range(1,2), Tooltip("Amount of hands required to wield the weapon.")]
        public int Hands;
        public enum Types
        {
            Staff,
            Sword,
            Dagger
        }

    }
}
