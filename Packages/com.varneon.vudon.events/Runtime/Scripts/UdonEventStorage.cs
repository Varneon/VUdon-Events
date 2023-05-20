using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Varneon.VUdon.UdonEvents
{
    public class UdonEventStorage : MonoBehaviour
    {
        public List<EventGroup> Events => _events;

        [SerializeField]
        private List<EventGroup> _events = new List<EventGroup>();

        [Serializable]
        public class EventGroup
        {
            public Component Target;

            public string EventName;

            public string EventDisplayName;

            public UdonEvent Event;

            public EventGroup(Component target, string eventName, string eventDisplayName)
            {
                Target = target;

                EventName = eventName;

                EventDisplayName = eventDisplayName;
            }
        }

        internal void CleanUpEventsOrSelf()
        {
            int removedEvents = _events.RemoveAll(e => e.Target == null);

            if (removedEvents > 0)
            {
                Debug.LogWarning(string.Concat("[<color=#ABCDEF>UdonEventStorage</color>]: ", removedEvents, " empty events removed on '<color=#888>", name, "</color>' due to missing targets!"));
            }

            if (_events.Count == 0)
            {
                Debug.LogWarning(string.Concat("[<color=#ABCDEF>UdonEventStorage</color>]: Found an event storage with no events on '<color=#888>", name, "</color>'! Removing storage..."));

                DestroyImmediate(this);
            }
        }

#if UNITY_EDITOR
        public bool TryBind(Component target, string eventName, string eventDisplayName)
        {
            if(_events.Any(e => e.Target.Equals(target) && e.EventName.Equals(eventName))) { return false; }

            UnityEditor.Undo.RecordObject(this, "Bind UdonEventStorage");

            _events.Add(new EventGroup(target, eventName, eventDisplayName));

            return true;
        }
#endif
    }
}
