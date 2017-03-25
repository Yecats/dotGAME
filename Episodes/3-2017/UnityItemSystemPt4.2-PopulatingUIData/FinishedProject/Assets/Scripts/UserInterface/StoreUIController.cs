using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UserInterface
{
    public class StoreUIController : MonoBehaviour
    {
        [SerializeField]
        private GameObject ItemTemplate;
        [SerializeField]
        private GameObject CurrencyTemplate;
        private MovementController _playerMoveController;
        private Transform _scrollViewContent;

        private void Start()
        {
            _playerMoveController = FindObjectOfType<MovementController>();
        }

        /// <summary>
        /// Populates the store list of inventory items
        /// </summary>
        /// <param name="inventoryList"></param>
        public void PopulateInventory(Inventory inventoryList)
        {

            ClearInventory();

            foreach (var item in inventoryList.InventoryItems)
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
            }
        }

        /// <summary>
        /// Clears out any existing inventory UI items
        /// </summary>
        public void ClearInventory()
        {
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
    }
}
