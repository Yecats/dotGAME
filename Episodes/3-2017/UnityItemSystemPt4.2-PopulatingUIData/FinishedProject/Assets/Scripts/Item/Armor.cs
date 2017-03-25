using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Items
{
    [CreateAssetMenu(menuName = "Item/Individual/Armor", fileName = "Armor Name")]
    public class Armor : Item
    {
        [Header("Armor Properties"), Tooltip("Slot that the armor can be equiped on.")]
        public Types ItemType;
        public enum Types
        {
            Head,
            Shoulders,
            Chest,
            Belt,
            Legs,
            Feet,
            Wrist,
            Hands
        }
    }
}
