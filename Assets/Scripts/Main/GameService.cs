using Assets.Scripts.Currency;
using Assets.Scripts.Items;
using Assets.Scripts.Player;
using UnityEngine;

namespace Assets.Scripts.Main
{
    class GameService : MonoBehaviour
    {
        [SerializeField] PlayerController playerController;
        [SerializeField] ItemService itemService;
        
        private CurrencyService currencyService;
        private void Awake()
        {
            currencyService = new CurrencyService(); 

            playerController.SetService(itemService,currencyService);
        }

    }
}