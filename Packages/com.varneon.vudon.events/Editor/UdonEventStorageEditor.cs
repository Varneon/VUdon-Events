using System;
using System.Reflection;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using static Varneon.VUdon.UdonEvents.UdonEventStorage;

namespace Varneon.VUdon.UdonEvents.Editor
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(UdonEventStorage))]
    public class UdonEventStorageEditor : UnityEditor.Editor
    {
        private static readonly Type easyEventEditorDrawerType = Type.GetType("Merlin.EasyEventEditorDrawer,UdonSharp.Editor");

        private MethodInfo EasyEventEditorDrawerOnGUI
        {
            get
            {
                if (easyEventEditorDrawerOnGUI == null)
                {
                    easyEventEditorDrawerOnGUI = easyEventEditorDrawerType.GetMethod("OnGUI", BindingFlags.Instance | BindingFlags.Public);
                }

                return easyEventEditorDrawerOnGUI;
            }
        }

        private MethodInfo easyEventEditorDrawerOnGUI;

        private object EasyEventEditorDrawer
        {
            get
            {
                if (easyEventEditorDrawer == null)
                {
                    easyEventEditorDrawer = Activator.CreateInstance(easyEventEditorDrawerType);
                }

                return easyEventEditorDrawer;
            }
        }

        private object easyEventEditorDrawer;

        private UnityEventDrawer EventDrawer
        {
            get
            {
                if (eventDrawer == null)
                {
                    eventDrawer = new UnityEventDrawer();
                }

                return eventDrawer;
            }
        }

        private UnityEventDrawer eventDrawer;

        internal int index = -1;

        private void OnEnable()
        {
            UdonEventStorage eventStorage = target as UdonEventStorage;

            if(eventStorage == null) { return; }

            foreach (UdonEventStorage storage in serializedObject.targetObjects)
            {
                storage.Editor = this;
            }

            eventStorage.CleanUpEventsOrSelf();
        }

        public override void OnInspectorGUI()
        {
            if(index < 0) { return; }

            serializedObject.Update();

            SerializedProperty eventsProperty = serializedObject.FindProperty("_events");

            if(index >= eventsProperty.arraySize) { index = -1; return; }

            SerializedProperty eventGroupProperty = eventsProperty.GetArrayElementAtIndex(index);

            SerializedProperty eventProperty = eventGroupProperty.FindPropertyRelative("Event");

            GUIContent label = new GUIContent(eventGroupProperty.FindPropertyRelative("EventDisplayName").stringValue);

            Rect rect = EditorGUILayout.GetControlRect(GUILayout.Height(EventDrawer.GetPropertyHeight(eventProperty, label)));

            using (EditorGUI.ChangeCheckScope scope = new EditorGUI.ChangeCheckScope())
            {
                // All reorderable effects from EEE are lost with PropertyField
                //EditorGUI.PropertyField(rect, eventProperty, label);

                // Default inspector works fully but EEE is lost
                //EventDrawer.OnGUI(rect, eventProperty, label);

                // Invoke EEE manually on the event field
                EasyEventEditorDrawerOnGUI.Invoke(EasyEventEditorDrawer, new object[] { rect, eventProperty, label });

                if (scope.changed)
                {
                    serializedObject.ApplyModifiedProperties();

                    // Allow event editing in playmode
                    if (Application.isPlaying)
                    {
                        UdonEventStorage eventStorage = (UdonEventStorage)serializedObject.targetObject;

                        EventGroup eventGroup = eventStorage.Events[index];

                        eventStorage.Target.SetProgramVariable(eventGroup.EventName, eventGroup.Event.ToDataList());
                    }
                }
            }

            index = -1;
        }
    }
}