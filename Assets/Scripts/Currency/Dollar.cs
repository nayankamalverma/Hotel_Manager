using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts.Currency
{
    public class Dollar : ICurrencyService
    {
        private int value;

        public Dollar(int initialBalance = 0) {
            value = PlayerPrefs.GetInt("dollor", initialBalance);
        }
        
        public void AddCurrency(int amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Amount to add cannot be negative.");
            }
            value += amount;
            UpdateValue();
        }

        public void SubtractCurrency(int amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Amount to subtract cannot be negative.");
            }
            if (value >= amount)
            {
                value -= amount;
            }
            UpdateValue();
        }
        public int GetCurrentBalance() => value;

        private void UpdateValue()
        {
            PlayerPrefs.SetInt("dollar", value);
        }
    }
}