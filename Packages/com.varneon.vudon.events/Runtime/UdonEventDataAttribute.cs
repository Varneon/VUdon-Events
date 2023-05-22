using System.Linq;
using UdonSharp;
using UnityEngine;

namespace Varneon.VUdon.UdonEvents
{
    public class UdonEventAttribute : PropertyAttribute
    {
        internal UdonEventStorage EventStorage;

        internal int EventIndex = -1;

        internal UdonEventStorage GetOrAddUdonEventStorage(UdonSharpBehaviour component, string eventName, string eventDisplayName)
        {
            if (EventStorage == null)
            {
                GameObject gameObject = component.gameObject;

                EventStorage = gameObject.GetComponents<UdonEventStorage>().FirstOrDefault(s => s.Target.Equals(component));

                if (EventStorage == null)
                {
                    EventStorage = gameObject.AddComponent<UdonEventStorage>();
                }
            }

            if (EventIndex < 0)
            {
                EventIndex = EventStorage.Events.FindIndex(e => e.EventName.Equals(eventName));

                if(EventIndex < 0)
                {
                    EventIndex = EventStorage.Events.Count;

                    EventStorage.TryBind(component, eventName, eventDisplayName);
                }

                EventStorage.Events[EventIndex].Attribute = this;
            }

            return EventStorage;
        }
    }
}
