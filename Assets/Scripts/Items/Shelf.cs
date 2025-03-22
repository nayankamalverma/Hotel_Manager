using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Items
{
    public class Shelf : IItemContainer
    {
        [SerializeField] private List<Transform> bottelPlace;
        [SerializeField] private float removeTime=3f;

        public void SetItem(Transform item)
        {
            Transform p = GetFirstEmptySpot();
            item.transform.SetParent(p);
            item.transform.position = p.position;
            StartCoroutine(ReturnItem(item.gameObject));
        }

        private IEnumerator ReturnItem(GameObject item)
        {
            yield return new WaitForSeconds(removeTime);
            itemService.bottelPool.ReturnBottel(item);
            item.transform.parent = null;
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
