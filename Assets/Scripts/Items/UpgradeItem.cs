using Assets.Scripts.Currency;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Items
{
    public class UpgradeItem : MonoBehaviour 
    {
        [SerializeField] TextMeshProUGUI costText;

        private Shelf shelf;
        private int cost;
        public void SetRefrences(Shelf shelf)
        {
            this.shelf = shelf;
            cost = shelf.GetInitUpgradeCost();
            UpdateCostText();
        }

        private void OnTriggerEnter(Collider other)
        {
            Dollar dollar = shelf.GetItemService().currencyService.dollar;
            if (other.CompareTag("Player") && dollar.GetCurrentBalance() >= cost)
            {
                dollar.SubtractCurrency(cost);
                shelf.IncreacePrice();
                cost += 20;
                UpdateCostText();
            }
            else
            {
                Debug.Log("not enough balance");
            }
        }

        private void UpdateCostText()
        {
            costText.text = "$ " + cost;
        }
    }
}