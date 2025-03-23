using Assets.Scripts.Items;
using Assets.Scripts.Utilities.Events;
using Unity.AI.Navigation;
using UnityEngine;

namespace Assets.Scripts.Main
{
    public class NavMeshService: MonoBehaviour
    {
        [SerializeField] NavMeshSurface meshSurface;
        private EventService eventService;

        public void SetService(EventService eventService)
        {
            this.eventService = eventService;
            eventService.OnItemUnlock.AddListener(BakeMesh);
        }
        public void BakeMesh(IItemContainer item)
        {
            meshSurface.BuildNavMesh();
        }
        private void OnDestroy()
        {
            eventService.OnItemUnlock.RemoveListener(BakeMesh);
        }
    }
}