using UnityEngine;
using System.Collections.Generic;
using Assets.Scripts.Items;
using System.Linq;

[CreateAssetMenu(menuName = "Item/Individual/Generic", fileName = "Generic Item Name")]
public class Item : ScriptableObject
{
    [Header("General Properties"), Tooltip("Name of the item to display on the UI.")]
    public string Name = "New Item";

    [Tooltip("Description to display on the UI."), Multiline(3)]
    public string Description = "Item Description";

    [Range(1,60), Tooltip("Minimum level required to use the item. 0 is no level requirement.")]
    public int MinimumLevel;

    [Tooltip("Image that is displayed on the UI.")]
    public Sprite Sprite;

    [Header("Trade Properties"), Tooltip("Currency and Price the player can purchase the item for.")]
    public List<CurrencyDefinition> PurchasePrice;

    [Range(0, 1), Tooltip("Deduction the merchant takes to purchase the item back.")]
    public float SellPriceReduction = 0.10f;

    public int PurchasePriceInCopper()
    {
        int copperCoins = 0;

        copperCoins += PurchasePrice.Where(x => x.Currency.Name.Equals("Copper Coin")).Select(s => s.Amount).DefaultIfEmpty(0).Single();
        copperCoins += PurchasePrice.Where(x => x.Currency.Name.Equals("Silver Coin")).Select(s => s.Amount).DefaultIfEmpty(0).Single() * 99;
        copperCoins += (PurchasePrice.Where(x => x.Currency.Name.Equals("Gold Coin")).Select(s => s.Amount).DefaultIfEmpty(0).Single() * 99) * 99;

        return copperCoins;
    }
    
}
