using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.NPC
{
    public class MerchantInteraction : MonoBehaviour
    {
        [SerializeField]
        private Inventory _inventoryList;
        [SerializeField]
        private GameObject _storeUI;
        private IEnumerator _storeUICoroutine;

        /// <summary>
        /// Shows the Store UI after the player has stopped moving. Is set to a 2 second delay once all criteria is made.
        /// </summary>
        /// <param name="moveController">Player movement controller which is used to evaluate when moving has stopped.</param>
        public IEnumerator WaitToShowStoreUI(MovementController moveController)
        {
            yield return new WaitUntil(() => moveController.IsMoving == false);
            yield return new WaitForSeconds(1f);

            _storeUI.transform.parent.gameObject.SetActive(true);
            _storeUI.SetActive(true);
        }

        /// <summary>
        /// Starts the coroutine that triggers the store UI. 
        /// This can be done by calling "StartCoroutine" directly and not storing the reference.
        /// Doing so runs the risk of adverse behaviors - such as Unity not being able to stop the coroutine. 
        /// </summary>
        /// <param name="moveController">Player movement controller which is used to evaluate when moving has stopped.</param>
        public void StartStoreUICoroutine(MovementController moveController)
        {
            //Check to make sure we do not have any running already
            if (_storeUICoroutine != null)
            {
                StopStoreUICoroutine();
            }
            //Start a new one
            _storeUICoroutine = WaitToShowStoreUI(moveController);
             StartCoroutine(_storeUICoroutine);
        }

        /// <summary>
        /// Stops the store UI courotine via the reference that was stored.
        /// </summary>
        public void StopStoreUICoroutine()
        {
            StopCoroutine(_storeUICoroutine);
            _storeUICoroutine = null;
        }
    }
}
