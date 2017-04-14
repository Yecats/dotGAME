using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Items
{
    [Serializable]
    public class CurrencyDefinition
    {
        public Currency Currency;
        public int Amount = 1;
    }
}
