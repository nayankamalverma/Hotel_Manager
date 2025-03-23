using UnityEngine;
using Assets.Scripts.Items;

namespace Assets.Scripts.Utiltities.ScriptableObjects
{
    [CreateAssetMenu(fileName = "ItemSO", menuName = "Scriptable Objects/ItemsSO")]
    public class ItemSO : ScriptableObject
	{
		public GameObject prefab;
		public int itemPrice=5;
		public float itemHeight;
		public ItemType itemType;
	}
}