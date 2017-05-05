using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Assets.Scripts.UserInterface
{
    public class ItemController : MonoBehaviour, IPointerClickHandler
    {
        public Item ItemDetails;
        public PlayerInventoryUIController PInventoryUIController;
        public bool HasItem;
        private GameObject _storeUI;


        private void Start()
        {
            _storeUI = GameObject.Find("UserInterface_Canvas").transform.FindChild("Store").gameObject; 
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            //If right clicking, and store UI is open... sell the item.
            if (eventData.button == PointerEventData.InputButton.Right && HasItem)
            {
                if (_storeUI.activeSelf)
                {
                    _storeUI.GetComponent<StoreUIController>().PurchaseItem(ItemDetails);
                }
                else
                {
                    PInventoryUIController.DestroyItem(ItemDetails);
                }

                //Clear out the UI & Metadata
                PInventoryUIController.ClearBagSlot(transform.parent.GetSiblingIndex());
                ClearItem();
            }
            
        }

        /// <summary>
        /// Set metadata about the UI that is being displayed. Used for interaction.
        /// </summary>
        /// <param name="item">Reference to the inventory item it represents</param>
        /// <param name="playerInvUIController">Reference to the UI controller that the item reference exists on</param>
        public void SetItemData(Item item, PlayerInventoryUIController playerInvUIController)
        {
            ItemDetails = item;
            PInventoryUIController = playerInvUIController;
            HasItem = true;
        }

        /// <summary>
        /// Clear all the details about the item
        /// </summary>
        public void ClearItem()
        {
            ItemDetails = null;
            PInventoryUIController = null;
            HasItem = false;
        }
    }
}
