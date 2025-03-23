
using Assets.Scripts.Utilities;
using UnityEngine;

namespace Assets.Scripts.Items
{
    public class DollarPool : ObjectPool
    {
        private GameObject prefab;

        public DollarPool(GameObject prefab)
        {
            this.prefab = prefab;
        }
        protected override GameObject CreateItem()
        {
            return Object.Instantiate(prefab);
        }
        public GameObject GetDollar() => GetItem();
        public void ReturnDollar(GameObject item)
        {
            var p = pooledItems.Find(i => i.item == item);
            ReturnItem(p);
        }
    }
}