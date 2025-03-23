using Assets.Scripts.Utiltities.ScriptableObjects;
using UnityEngine;
using System.Collections.Generic;
using System;
using Assets.Scripts.Utilities.Events;

namespace Assets.Scripts.Items
{
	public class ItemService : MonoBehaviour
	{
		[SerializeField] ItemSO bottel1;
		[SerializeField] List<IItemContainer> shelfs;
		[SerializeField] GameObject dollarPrefab;
		
		public EventService eventService { get; private set; }
		public BottelPool bottelPool {  get; private set; }
		public DollarPool dollarPool { get; private set; }

		private void Start()
		{
			bottelPool = new BottelPool(bottel1.prefab);
			dollarPool = new DollarPool(dollarPrefab);
		}

        public void SetServices(EventService eventService)
        {
			this.eventService = eventService;
			foreach(var s in shelfs)
			{
				s.SetService(this);
			}
        }

		private void OnNewShelfUnlock(IItemContainer item)
		{
			shelfs.Add(item);
			item.SetService(this);
		}

        public GameObject GetItem(ItemType type)
		{
			if (type == ItemType.Bottel1)return bottelPool.GetBottel();
			return null;
		}

		public float getItemHight(ItemType item)
		{
			if (item == ItemType.Bottel1) return bottel1.itemHeight;
			return 0;
		}

		public void ReturnItem(ItemType type, GameObject item)
		{
			if (type == ItemType.Bottel1) bottelPool.ReturnBottel(item);
		}
	}
}