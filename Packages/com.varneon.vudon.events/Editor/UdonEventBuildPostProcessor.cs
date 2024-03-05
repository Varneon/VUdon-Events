using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UdonSharp;
using UdonSharpEditor;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.SceneManagement;
using VRC.SDK3.Data;

namespace Varneon.VUdon.UdonEvents.Editor
{
    internal static class UdonEventBuildPostProcessor
    {
        private static UdonEventHandler eventHandler;

        private const string LOG_PREFIX = "[<color=#ABC>VUdon</color>][<color=#ABCDEF>UdonEvents</color>]: ";

        [UsedImplicitly]
        [PostProcessScene(-1)]
        private static void PostProcessUdonEvents()
        {
            GameObject[] roots = SceneManager.GetActiveScene().GetRootGameObjects();

            foreach(UdonSharpBehaviour behaviour in roots.SelectMany(r => r.GetComponentsInChildren<UdonSharpBehaviour>(true)))
            {
                PostProcessUdonEventsOnUdonSharpBehaviour(behaviour);
            }
        }

        private static void PostProcessUdonEventsOnUdonSharpBehaviour(UdonSharpBehaviour behaviour)
        {
            IEnumerable<FieldInfo> fields = behaviour.GetType().GetRuntimeFields();

            Dictionary<string, FieldInfo> eventDataFields = new Dictionary<string, FieldInfo>();

            if(!behaviour.gameObject.TryGetComponent(out UdonEventStorage _)) { return; }

            UdonEventStorage eventStorage = behaviour.GetComponents<UdonEventStorage>().FirstOrDefault(s => s.Target.Equals(behaviour));

            if(eventStorage == null) { return; }

            foreach (FieldInfo field in fields)
            {
                if (Attribute.IsDefined(field, typeof(UdonEventAttribute)))
                {
                    int eventIndex = eventStorage.Events.FindIndex(e => e.EventName.Equals(field.Name));
                    
                    if(eventIndex < 0) { Debug.LogWarning(string.Concat(LOG_PREFIX, nameof(UdonEventStorage), " on '", behaviour.name, "' doesn't have an event stored for '", field.Name, "' in ", behaviour.GetType().FullName, "!"), behaviour.gameObject); continue; }

                    DataList data = eventStorage.Events[eventIndex].Event.ToDataList();

                    field.SetValue(behaviour, data);
                }
                else if (field.FieldType.Equals(typeof(UdonEventHandler)))
                {
                    field.SetValue(behaviour, GetOrAddUdonEventHandler());
                }
            }
        }

        private static UdonEventHandler GetOrAddUdonEventHandler()
        {
            if(eventHandler == null)
            {
                eventHandler = SceneManager.GetActiveScene().GetRootGameObjects().Select(r => r.GetComponentInChildren<UdonEventHandler>(true)).FirstOrDefault();

                if(eventHandler == null)
                {
                    eventHandler = new GameObject(nameof(UdonEventHandler)).AddUdonSharpComponent<UdonEventHandler>();

                    UdonSharpEditorUtility.GetBackingUdonBehaviour(eventHandler).SyncMethod = VRC.SDKBase.Networking.SyncType.None;
                }
            }

            return eventHandler;
        }
    }
}
