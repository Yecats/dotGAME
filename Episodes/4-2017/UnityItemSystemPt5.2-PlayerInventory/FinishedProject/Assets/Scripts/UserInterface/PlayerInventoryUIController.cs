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

            //Add Inventory Slots
            for (int i = 0; i < PlayerInventory.InventoryItems.Count; i++)
            {
                _scrollViewContent.GetChild(i).FindChild("ItemImage").GetComponent<Image>().sprite = PlayerInventory.InventoryItems[i].Sprite;
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

        public void PurchaseItem(Item itemPurchased)
        {
            //deduct the money from the player
            PlayerInventory.CopperCoins -= itemPurchased.PurchasePriceInCopper();
            UpdateCurrency();

            //add the item to the players inventory
            PlayerInventory.InventoryItems.Add(itemPurchased);

            //add it to the UI screen
            _scrollViewContent.GetChild(PlayerInventory.InventoryItems.Count - 1).FindChild("ItemImage").GetComponent<Image>().sprite = PlayerInventory.InventoryItems[PlayerInventory.InventoryItems.Count - 1].Sprite;
        }
        
    }
}
