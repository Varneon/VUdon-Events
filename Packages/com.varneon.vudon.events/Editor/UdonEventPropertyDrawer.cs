using System.Linq;
using UdonSharp;
using UnityEditor;
using UnityEngine;

namespace Varneon.VUdon.UdonEvents.Editor
{
    [CustomPropertyDrawer(typeof(UdonEventAttribute))]
    public class UdonEventPropertyDrawer : PropertyDrawer
    {
        private UdonEventStorageEditor storageEditor;

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return 0f;
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            UdonEventAttribute eventAttribute = (UdonEventAttribute)attribute;

            eventAttribute.GetOrAddUdonEventStorage((UdonSharpBehaviour)property.serializedObject.targetObject, property.name, property.displayName);

            GameObject[] gameObjects = Selection.gameObjects;

            if (gameObjects.Length > 1 && gameObjects.Select(g => g.GetComponents<UdonEventStorage>().Length).Max() > 1)
            {
                GUILayout.Label(property.displayName);

                EditorGUILayout.HelpBox("Multi-object editing of UdonEvents is only supported for objects with one UdonSharpBehaviour of the same type which use UdonEvents", MessageType.Warning);

                return;
            }

            storageEditor = (UdonEventStorageEditor)eventAttribute.EventStorage.Editor;

            if(storageEditor == null) { return; }

            storageEditor.index = eventAttribute.EventIndex;

            storageEditor.OnInspectorGUI();
        }
    }
}
