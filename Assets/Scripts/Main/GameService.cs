using Assets.Scripts.Items;
using Assets.Scripts.Player;
using UnityEngine;

namespace Assets.Scripts.Main
{
    class GameService : MonoBehaviour
    {
        [SerializeField] PlayerController playerController;
        [SerializeField] ItemService itemService;

        private void Awake()
        {
            playerController.SetService(itemService);
        }

    }
}