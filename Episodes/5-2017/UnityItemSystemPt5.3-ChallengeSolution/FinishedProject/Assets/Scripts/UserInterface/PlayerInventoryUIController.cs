using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UserInterface
{
    public class PlayerInventoryUIController : MonoBehaviour
    {
        [SerializeField]
        public PlayerInventoryDetails PlayerInventory;
        public Sprite DefaultBagSprite; 
        private GameObject _playerInventoryWindow;
        private Text _goldCurrencyText;
        private Text _silverCurrencyText;
        private Text _copperCurrencyText;
        private Text _BagSpaceText;

        //Templates
        [SerializeField]
        private GameObject _itemTemplate;
        private Transform _scrollViewContent;

        private void Awake()
        {
            _playerInventoryWindow = transform.parent.parent.FindChild("Player_Inventory").gameObject;
            _goldCurrencyText = _playerInventoryWindow.transform.FindChild("Footer/CurrecnyDetails/Coin_Gold/Text").GetComponent<Text>();
            _silverCurrencyText = _playerInventoryWindow.transform.FindChild("Footer/CurrecnyDetails/Coin_Silver/Text").GetComponent<Text>();
            _copperCurrencyText = _playerInventoryWindow.transform.FindChild("Footer/CurrecnyDetails/Coin_Copper/Text").GetComponent<Text>();
            _BagSpaceText = _playerInventoryWindow.transform.FindChild("Footer/BagDetails/Amount").GetComponent<Text>();
            _scrollViewContent = _playerInventoryWindow.transform.FindChild("Scroll View/Viewport/Content");
        }

        private void Start()
        {

            //update bag text
            _BagSpaceText.text = string.Format("{0}/{1} ", PlayerInventory.TotalBagSlots - PlayerInventory.InventoryItems.Count, PlayerInventory.TotalBagSlots);

            //Create bag slots
            for (int i = 0; i < PlayerInventory.TotalBagSlots; i++)
            {
                GameObject newItem = Instantiate(_itemTemplate, _scrollViewContent);
                newItem.transform.localScale = Vector3.one;
            }

            //Add Inventory items
            for (int i = 0; i < PlayerInventory.InventoryItems.Count; i++)
            {
                CreateInventoryItem(i);
            }

            UpdateCurrency();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                ToggleWindow();
            }
        }

        /// <summary>
        /// Updating an existing bag slot with an inventory item
        /// </summary>
        /// <param name="index"></param>
        private void CreateInventoryItem(int index)
        {
            foreach (Transform slot in _scrollViewContent.transform)
            {
                if (!slot.FindChild("ItemImage").GetComponent<ItemController>().HasItem)
                {
                    slot.FindChild("ItemImage").GetComponent<Image>().sprite = PlayerInventory.InventoryItems[index].Sprite;
                    slot.name = PlayerInventory.InventoryItems[index].Name;

                    slot.GetComponentInChildren<ItemController>().SetItemData(PlayerInventory.InventoryItems[index], this);

                    return;
                }
            }
        }

        public void ClearBagSlot(int index)
        {
            _scrollViewContent.GetChild(index).FindChild("ItemImage").GetComponent<Image>().sprite = DefaultBagSprite;
        }
        
        /// <summary>
        /// Update the currency amounts that are displayed on the UI.
        /// </summary>
        public void UpdateCurrency()
        {
            int[] cur = PlayerInventory.GetCoinByCurrency();

            //Display on the UI
            _copperCurrencyText.text = cur[0].ToString();
            _silverCurrencyText.text = cur[1].ToString();
            _goldCurrencyText.text = cur[2].ToString();
        }

        /// <summary>
        /// Toggles the visibility state of the Inventory Window.
        /// </summary>
        public void ToggleWindow()
        {
            _playerInventoryWindow.SetActive(!_playerInventoryWindow.activeSelf);
        }

        /// <summary>
        /// Finish the purchase transaction by deducting the currency and refreshing the UI
        /// </summary>
        /// <param name="itemPurchased">The item that was purchased</param>
        public void PurchaseItem(Item itemPurchased)
        {
            //deduct the money from the player
            PlayerInventory.CopperCoins -= itemPurchased.PurchasePriceInCopper(false);
            UpdateCurrency();

            //add the item to the players inventory
            PlayerInventory.InventoryItems.Add(itemPurchased);

            //add it to the UI screen
            CreateInventoryItem(PlayerInventory.InventoryItems.Count - 1);
        }

        /// <summary>
        /// Sell the item back to the merchant, taking into account the sell reduction percentage
        /// </summary>
        /// <param name="itemToSell">The item the player wants to sell</param>
        public void SellItem(Item itemToSell)
        {
            PlayerInventory.CopperCoins += itemToSell.PurchasePriceInCopper(true);
            PlayerInventory.InventoryItems.Remove(itemToSell);
        }

        public void DestroyItem(Item itemToDestroy)
        {
            PlayerInventory.InventoryItems.Remove(itemToDestroy);
        }

    }
}
