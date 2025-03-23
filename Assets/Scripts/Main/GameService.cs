using Assets.Scripts.Currency;
using Assets.Scripts.Items;
using Assets.Scripts.Player;
using Assets.Scripts.UI;
using Assets.Scripts.Unlock;
using Assets.Scripts.Utilities.Events;
using UnityEngine;

namespace Assets.Scripts.Main
{
    class GameService : MonoBehaviour
    {
        [SerializeField] PlayerController PlayerController;
        [SerializeField] ItemService ItemService;
        [SerializeField] UIService UIService;
        [SerializeField] UnlockService UnlockService;
        [SerializeField] NavMeshService NavMeshService;

        private EventService eventService;
        private CurrencyService currencyService;
        private void Awake()
        {
            //to be removed
            PlayerPrefs.DeleteAll();
            eventService = new EventService();
            currencyService = new CurrencyService();

            PlayerController.SetService(ItemService, currencyService);
            ItemService.SetServices(eventService, currencyService);
            UIService.SetService(eventService);
            UnlockService.SetService(eventService, currencyService);
            NavMeshService.SetService(eventService);
        }

    }
}