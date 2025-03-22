
using Assets.Scripts.Utilities;
using UnityEngine;

namespace Assets.Scripts.Items
{
	public class BottelPool:ObjectPool { 
		private GameObject prefab;

        public BottelPool(GameObject prefab)
        {
            this.prefab = prefab;
        }
        protected override GameObject CreateItem()
        {
            return Object.Instantiate(prefab);
        }
        public GameObject GetBottel()=>GetItem();
        public void ReturnBottel(GameObject item) {
            var p = pooledItems.Find(i=>i.item == item);
            ReturnItem(p);
        }
    }
}