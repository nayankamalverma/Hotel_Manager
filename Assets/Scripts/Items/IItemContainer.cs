using UnityEngine;

namespace Assets.Scripts.Items
{
    public class IItemContainer: MonoBehaviour
    {
        protected ItemService itemService;
        public bool isUsed { get; set; }

        public void SetService(ItemService itemService)
        {
            this.itemService = itemService;
        }
    }
}