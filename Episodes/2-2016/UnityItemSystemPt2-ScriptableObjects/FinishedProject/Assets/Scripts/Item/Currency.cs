using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Items
{
    [CreateAssetMenu(menuName = "Item/Currency", fileName = "Generic Currency Name")]
    public class Currency : ScriptableObject
    {
        public string Name;
        public Sprite Image;
    }
}
