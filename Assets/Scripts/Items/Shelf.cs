using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Assets.Scripts.Items
{
	public class Shelf : IItemContainer
	{
		[SerializeField] private List<Transform> bottelPlace;
		[SerializeField] private float removeTime=3f;
		[SerializeField] private Transform dollarPlace;

		private float YAxis;
		private int itemCnt=0;
		int delay = 0, dollarPlaceIndex ;

        private void Start()
		{
			itemCnt = 0;
			YAxis = 0;
			dollarPlaceIndex = 0;
		}
		private void MakeMoney()
		{
			GameObject newDollar = itemService.dollarPool.GetDollar();
			newDollar.transform.position = dollarPlace.GetChild(dollarPlaceIndex).position;
			newDollar.transform.rotation = dollarPlace.GetChild(dollarPlaceIndex).rotation;
			
			if (dollarPlaceIndex < dollarPlace.childCount - 1){
                dollarPlaceIndex++;
			}
			else
			{
                dollarPlaceIndex = 0;
				YAxis += 0.5f;
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
	}
}
