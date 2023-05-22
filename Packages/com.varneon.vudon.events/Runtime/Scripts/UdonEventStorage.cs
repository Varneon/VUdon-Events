using System;
using System.Collections.Generic;
using UdonSharp;
using UnityEngine;

namespace Varneon.VUdon.UdonEvents
{
    [AddComponentMenu("")]
    public class UdonEventStorage : MonoBehaviour
    {
        internal ScriptableObject Editor;

        internal UdonSharpBehaviour Target => _target;

        [SerializeField]
        private UdonSharpBehaviour _target;

        internal List<EventGroup> Events => _events;

        [SerializeField]
        private List<EventGroup> _events = new List<EventGroup>();

        [Serializable]
        public class EventGroup
        {
            public UdonEventAttribute Attribute;

            public string EventName;

            public string EventDisplayName;

            public UdonEvent Event;

            public EventGroup(string eventName, string eventDisplayName)
            {
                EventName = eventName;

                EventDisplayName = eventDisplayName;
            }
        }

        internal void CleanUpEventsOrSelf()
        {
            if(_target == null)
            {
                Debug.LogWarning(string.Concat("[<color=#ABCDEF>UdonEventStorage</color>]: Found an event storage with no target on '<color=#888>", name, "</color>'! Removing storage..."));

                DestroyImmediate(this);
                
                return;
            }
        }

        internal bool TryBind(UdonSharpBehaviour target, string eventName, string eventDisplayName)
        {
            if (_target != null && _target != target) { return false; }

#if UNITY_EDITOR
            UnityEditor.Undo.RecordObject(this, "Bind UdonEventStorage");
#endif

            _target = target;

            _events.Add(new EventGroup(eventName, eventDisplayName));

            return true;
        }
    }
}
