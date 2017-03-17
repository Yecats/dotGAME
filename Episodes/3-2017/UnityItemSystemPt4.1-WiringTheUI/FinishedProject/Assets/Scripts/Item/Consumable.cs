using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Items
{
    [CreateAssetMenu(menuName = "Item/Individual/Consumable", fileName = "Consumable Name")]
    public class Consumable : Item
    {
        [Header("Consumable Properties"), Tooltip("Type of consumable.")]
        public Types ItemType;
        public float Amount;
        public enum Types
        {
            ManaPotion,
            HealingPotion,
            Poision
        }

    }
}
