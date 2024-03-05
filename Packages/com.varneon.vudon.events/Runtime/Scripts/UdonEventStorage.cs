#if !COMPILER_UDONSHARP

using System;
using System.Collections.Generic;
using System.Linq;
using UdonSharp;
using UnityEditor;
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

        [SerializeField]
        private List<EventGroup> _eventsBackup;

        [SerializeField]
        private bool _backupAvailable;

        private const string LOG_PREFIX = "[<color=#ABC>VUdon</color>][<color=#ABCDEF>UdonEvents</color>]: ";

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

#if UNITY_EDITOR
            private EventGroup(UdonEventAttribute attribute, string eventName, string eventDisplayName, UdonEvent udonEvent)
            {
                Attribute = attribute;

                EventName = eventName;

                EventDisplayName = eventDisplayName;

                Event = udonEvent.Clone();
            }

            public EventGroup Copy()
            {
                return new EventGroup(Attribute, EventName, EventDisplayName, Event);
            }
#endif
        }

        internal void CleanUpEventsOrSelf()
        {
            if(_target == null)
            {
                Debug.LogWarning(string.Concat(LOG_PREFIX, "Found an event storage with no target on '<color=#888>", name, "</color>'! Removing storage..."));

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

#if UNITY_EDITOR
        public void BackUpEvents(bool withUndo = true)
        {
            if (withUndo)
            {
                Undo.RegisterCompleteObjectUndo(this, "Back Up UdonEvents");
            }

            _eventsBackup = new List<EventGroup>(_events.Select(e => e.Copy()));

            _backupAvailable = true;
        }

        public void RestoreEventsFromBackup(bool withUndo = true)
        {
            if (withUndo)
            {
                Undo.RegisterCompleteObjectUndo(this, "Restore UdonEvents From Backup");
            }

            if (!_backupAvailable) { Debug.LogWarning(string.Concat(LOG_PREFIX, "No backup available for ", name, "!"), this); return; }

            _events = new List<EventGroup>(_eventsBackup.Select(e => e.Copy()));
        }
#endif
    }
}

#endif
