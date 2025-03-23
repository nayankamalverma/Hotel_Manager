using Assets.Scripts.Items;

namespace Assets.Scripts.Utilities.Events
{

    public class EventService
    {
        public EventController<IItemContainer> OnItemUnlock;

        public EventService() 
        { 
            OnItemUnlock = new EventController<IItemContainer>();
        }
    }
}