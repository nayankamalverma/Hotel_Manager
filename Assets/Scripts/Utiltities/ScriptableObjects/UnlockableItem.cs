using Assets.Scripts.Items;
using UnityEngine;

namespace Assets.Scripts.Utiltities.ScriptableObjects
{
    [CreateAssetMenu(fileName = "UnlockableItem", menuName = "Game/UnlockableItem")]
    public class UnlockableItem : ScriptableObject
    {
        public ItemType itemType;
        public int unlockCost; 
        public GameObject prefab; 
    }
}