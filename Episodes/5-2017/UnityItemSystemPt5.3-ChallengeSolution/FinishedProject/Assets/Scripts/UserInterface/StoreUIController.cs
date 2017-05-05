using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.UserInterface
{
    public class StoreUIController : MonoBehaviour
    {
        public MerchantInventoryDetails MerchantInventory;

        [SerializeField]
        private GameObject ItemTemplate;
        [SerializeField]
        private GameObject CurrencyTemplate;
        private MovementController _playerMoveController;
        private Transform _scrollViewContent;

        private PlayerInventoryUIController _playerInventoryUI;

        private void Start()
        {
            _playerMoveController = FindObjectOfType<MovementController>();
            _playerInventoryUI = FindObjectOfType<PlayerInventoryUIController>();
        }

        /// <summary>
        /// Populates the store list of inventory items
        /// </summary>
        /// <param name="inventoryList"></param>
        public void PopulateInventory(MerchantInventoryDetails inventoryList)
        {
            ClearInventory();
            MerchantInventory = inventoryList;

            foreach (var item in inventoryList.InventoryItems)
            {
                CreateInventoryItem(item);
            }
        }

        /// <summary>
        /// Create the logic for 
        /// </summary>
        /// <param name="item"></param>
        public void CreateInventoryItem(Item item)
        {
            GameObject newItem = Instantiate(ItemTemplate, _scrollViewContent);

            newItem.transform.localScale = Vector3.one;
            newItem.transform.FindChild("Image/ItemImage").GetComponent<Image>().sprite = item.Sprite;
            newItem.transform.FindChild("Name").GetComponent<Text>().text = item.Name;
            newItem.transform.FindChild("Description").GetComponent<Text>().text = item.Description;

            foreach (var cur in item.PurchasePrice)
            {
                GameObject newCurrency = Instantiate(CurrencyTemplate, newItem.transform.FindChild("Currency/List"));

                newCurrency.transform.localScale = Vector3.one;
                newCurrency.transform.FindChild("Image").GetComponent<Image>().sprite = cur.Currency.Image;
                newCurrency.transform.FindChild("Amount").GetComponent<Text>().text = cur.Amount.ToString();

            }

            newItem.transform.FindChild("Currency/BuyBtn").GetComponent<Button>().onClick.AddListener(BuyOnClick);
        }

        /// <summary>
        /// Clears out any existing inventory UI items
        /// </summary>
        public void ClearInventory()
        {
            MerchantInventory = null;

            //Since this starts out as disabled, we need to do a check the first time we try to access the content element, as we may not have a reference to it.
            if (_scrollViewContent == null)
            {
                _scrollViewContent = transform.FindChild("Scroll View/Viewport/Content");
            }

            foreach (Transform child in _scrollViewContent)
            {
                Destroy(child.gameObject);
            }
        }

        /// <summary>
        /// Close the Store UI Window
        /// </summary>
        public void CloseWindow()
        {
            gameObject.SetActive(false);
            _playerMoveController.IsMovementLocked = false;
        }

        /// <summary>
        /// Completes a purchase transaction after confirming funds are available
        /// </summary>
        public void BuyOnClick()
        {
            Item purchasedItem = MerchantInventory.InventoryItems.Find(x => x.Name.Equals(EventSystem.current.currentSelectedGameObject.transform.parent.parent.FindChild("Name").GetComponent<Text>().text));

            //Make sure we can find the item and a can afford it
            if (purchasedItem == null)
            {
                Debug.Log("Unable to find item in merchant DB");
                return;
            }
            else if (purchasedItem.PurchasePriceInCopper(false) >= _playerInventoryUI.PlayerInventory.CopperCoins)
            {
                Debug.Log(string.Format("Not enough currency. Purchase Price: {0}; Player Coins: {1}", purchasedItem.PurchasePriceInCopper(false), _playerInventoryUI.PlayerInventory.CopperCoins));
                return;
            }

            _playerInventoryUI.PurchaseItem(purchasedItem);

            MerchantInventory.InventoryItems.Remove(purchasedItem);

            PopulateInventory(MerchantInventory);
        }

        /// <summary>
        /// Add the item to the active merchants inventory and display it on the UI
        /// </summary>
        /// <param name="itemPurchased">Item that was sold back to the merchant</param>
        public void PurchaseItem(Item itemPurchased) {

            _playerInventoryUI.SellItem(itemPurchased);
            MerchantInventory.InventoryItems.Add(itemPurchased);

            CreateInventoryItem(itemPurchased);
        }



    }
}
