using UnityEditor;
using UnityEngine;

namespace Varneon.VUdon.UdonEvents.Editor
{
    [CustomPropertyDrawer(typeof(UdonEventAttribute))]
    public class UdonEventPropertyDrawer : PropertyDrawer
    {
        private UdonEventStorageEditor storageEditor;

        private UdonEventStorage eventStorage;

        private int eventIndex;

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return 0f;
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            GetOrCreateStorageEditor(property).OnProxyInspectorGUI(eventIndex);
        }

        private UdonEventStorage GetOrAddUdonEventStorage(Component component, string eventName, string eventDisplayName)
        {
            if(eventStorage == null)
            {
                GameObject gameObject = component.gameObject;

                if(!gameObject.TryGetComponent(out eventStorage))
                {
                    eventStorage = gameObject.AddComponent<UdonEventStorage>();
                }
            }

            eventIndex = eventStorage.Events.FindIndex(e => e.Target.Equals(component) && e.EventName.Equals(eventName));

            if(eventIndex < 0)
            {
                eventIndex = eventStorage.Events.Count;

                eventStorage.TryBind(component, eventName, eventDisplayName);
            }

            return eventStorage;
        }

        private UdonEventStorageEditor GetOrCreateStorageEditor(SerializedProperty property)
        {
            if(storageEditor == null)
            {
                storageEditor = (UdonEventStorageEditor)UnityEditor.Editor.CreateEditor(GetOrAddUdonEventStorage((Component)property.serializedObject.targetObject, property.name, property.displayName), typeof(UdonEventStorageEditor));
            }

            return storageEditor;
        }
    }
}
