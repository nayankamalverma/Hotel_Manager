using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Utiltities.ScriptableObjects;
using UnityEngine;

namespace Assets.Scripts.Items
{
	public class Shelf : IItemContainer
	{
		[SerializeField] private List<Transform> bottelPlace;
		[SerializeField] private float removeTime=3f;
		[SerializeField] private Transform dollarPlace;
		[SerializeField] private ItemSO itemSO;
		[SerializeField] private int initUpgradeCost;
		[SerializeField] private UpgradeItem upgradeItem;

		private int itemCnt=0;
		int delay = 0, dollarPlaceIndex ;
		int cost = 0;
		int level;
		int maxLevel = 5;

        private void Start()
		{
			cost = itemSO.itemPrice;
			level = 1;
			itemCnt = 0;
			dollarPlaceIndex = 0;
			upgradeItem.SetRefrences(this);
		}
		private void MakeMoney()
		{
			int cnt = cost/5;
			while(cnt>0){
				GameObject newDollar = itemService.dollarPool.GetDollar();
				newDollar.transform.position = dollarPlace.GetChild(dollarPlaceIndex).position;
				newDollar.transform.rotation = dollarPlace.GetChild(dollarPlaceIndex).rotation;

				if (dollarPlaceIndex < dollarPlace.childCount - 1)
				{
					dollarPlaceIndex++;
				}
				else
				{
					dollarPlaceIndex = 0;
				}
				cnt--;
			}
		}

		public void SetItem(Transform item)
		{
			delay = 2 * itemCnt;
			Transform p = GetFirstEmptySpot();
			item.transform.SetParent(p);
			item.transform.position = p.position;
			StartCoroutine(ReturnItem(item.gameObject,removeTime+delay));
			itemCnt++;
		}

		private IEnumerator ReturnItem(GameObject item, float time)
		{
			yield return new WaitForSeconds(time);
			itemService.bottelPool.ReturnBottel(item);
			item.transform.parent = null;
			MakeMoney();
			itemCnt--;
            if (itemCnt == 0) delay = 0;
        } 
		public bool HasEmptySpot()
		{
			foreach (Transform spot in bottelPlace)
			{
				if (spot.childCount == 0)
				{
					return true;
				}
			}
			return false;
		}
		public void IncreacePrice()
		{
			cost += 5; //can add a multiplier variable in itemSo 
			level++;
			if(level==maxLevel)upgradeItem.gameObject.SetActive(false);
		}
		private Transform GetFirstEmptySpot()
		{
			foreach (Transform spot in bottelPlace)
			{
				if (spot.childCount == 0)
				{
					return spot;
				}
			}
			return null;
		}
		public int GetInitUpgradeCost() => initUpgradeCost;
	}
}
