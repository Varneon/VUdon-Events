using UdonSharp;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace Varneon.VUdon.UdonEvents.Editor
{
    [CustomEditor(typeof(UdonEventStorage))]
    public class UdonEventStorageEditor : UnityEditor.Editor
    {
        private UnityEventDrawer eventDrawer;

        private SerializedProperty eventsProperty;

        private void OnEnable()
        {
            UdonEventStorage eventStorage = target as UdonEventStorage;

            if(eventStorage == null) { return; }

            eventDrawer = new UnityEventDrawer();

            eventsProperty = serializedObject.FindProperty("_events");

            eventStorage.CleanUpEventsOrSelf();
        }

        public override void OnInspectorGUI() { }

        public void OnProxyInspectorGUI(int eventIndex)
        {
            UdonEventStorage eventStorage = (UdonEventStorage)target;

            serializedObject.Update();

            UdonEventStorage.EventGroup eventGroup = eventStorage.Events[eventIndex];

            GUIContent label = new GUIContent(eventGroup.EventDisplayName);

            SerializedProperty eventGroupProperty = eventsProperty.GetArrayElementAtIndex(eventIndex);

            SerializedProperty eventProperty = eventGroupProperty.FindPropertyRelative("Event");

            Rect rect = EditorGUILayout.GetControlRect(GUILayout.Height(eventDrawer.GetPropertyHeight(eventProperty, label)));

            using (EditorGUI.ChangeCheckScope scope = new EditorGUI.ChangeCheckScope())
            {
                EditorGUI.PropertyField(rect, eventProperty, label);

                if(scope.changed)
                {
                    serializedObject.ApplyModifiedProperties();

                    if (Application.isPlaying)
                    {
                        ((UdonSharpBehaviour)eventGroup.Target).SetProgramVariable(eventGroup.EventName, eventGroup.Event.ToDataList());
                    }
                }
            }
        }
    }
}