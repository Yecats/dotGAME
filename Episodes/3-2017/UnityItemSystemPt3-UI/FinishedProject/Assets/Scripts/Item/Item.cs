using UnityEngine;
using System.Collections.Generic;
using Assets.Scripts.Items;

[CreateAssetMenu(menuName = "Item/Generic", fileName = "Generic Item Name")]
public class Item : ScriptableObject
{
    [Header("General Properties"), Tooltip("Name of the item to display on the UI.")]
    public string Name = "New Item";

    [Tooltip("Description to display on the UI."), Multiline(3)]
    public string Description = "Item Description";

    [Range(1,60), Tooltip("Minimum level required to use the item. 0 is no level requirement.")]
    public int MinimumLevel;

    [Tooltip("Image that is displayed on the UI.")]
    public Texture2D Sprite;

    [Header("Trade Properties"), Tooltip("Currency and Price the player can purchase the item for.")]
    public CurrencyDefinition[] PurchasePrice;

    [Range(0, 1), Tooltip("Deduction the merchant takes to purchase the item back.")]
    public float SellPriceReduction = 0.10f;

}
