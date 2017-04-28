using Assets.Scripts.Items;
using Assets.Scripts.UserInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[CreateAssetMenu(menuName = "Item/PlayerInventory", fileName = "NewPlayerInventory")]
public class PlayerInventoryDetails : ScriptableObject
{
    public int CopperCoins;
    public List<Item> InventoryItems;
    //public int CopperCoins;
    [Range(5, 50)]
    public int TotalBagSlots;

    /// <summary>
    /// Calculates the amount of coin, broken down by type (Gold, Silver, and Copper)
    /// </summary>
    /// <returns>An array that contains the total coin, broken down by gold, silver and copper (in that order).</returns>
    public int[] GetCoinByCurrency()
    {
        int[] currency = new int[] { 0, 0, 0 };

        currency[0] = CopperCoins % 99;
        currency[1] = (CopperCoins / 99) % 99;
        currency[2] = (CopperCoins / 99) / 99;

        return currency;
    }
}
