using Assets.Scripts.Currency;
using Assets.Scripts.Utilities.Events;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Unlock
{
    public class UnlockService : MonoBehaviour
    {
        [SerializeField] private List<UnlockObject> unlockableItems;

        public EventService eventService { get; private set; }
        public CurrencyService currencyService { get; private set; }

        public void SetService(EventService eventService, CurrencyService currencyService)
        {
            this.eventService = eventService;
            this.currencyService = currencyService;

            SetServices();
        }

        private void SetServices()
        {
            foreach(var i in unlockableItems)
            {
                i.SetService(this);
            }
        }
    }
}