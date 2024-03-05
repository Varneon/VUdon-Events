#if !COMPILER_UDONSHARP

using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine.Events;
using VRC.SDK3.Data;

namespace Varneon.VUdon.UdonEvents
{
    [Serializable]
    public class UdonEvent : UnityEvent
    {
#if UNITY_EDITOR
        private const BindingFlags BINDING_FLAGS = BindingFlags.Instance | BindingFlags.NonPublic;

        public UdonEvent Clone()
        {
            UdonEvent newUdonEvent = (UdonEvent)Activator.CreateInstance(GetType());

            FieldInfo callGroupField = typeof(UnityEventBase).GetField("m_PersistentCalls", BINDING_FLAGS);

            var callGroup = callGroupField.GetValue(this);

            Type persistentCallGroupType = callGroup.GetType();

            FieldInfo callsField = persistentCallGroupType.GetField("m_Calls", BINDING_FLAGS);

            var persistentCalls = callsField.GetValue(callGroup);

            var newPersistentCalls = callsField.GetValue(callGroupField.GetValue(newUdonEvent));

            MethodInfo addMethod = newPersistentCalls.GetType().GetMethod("Add");

            foreach (object call in persistentCalls as IEnumerable<object>)
            {
                Type persistentCallType = call.GetType();

                var newCall = Activator.CreateInstance(persistentCallType);

                FieldInfo targetField = persistentCallType.GetField("m_Target", BINDING_FLAGS);
                targetField.SetValue(newCall, targetField.GetValue(call));

                FieldInfo methodNameField = persistentCallType.GetField("m_MethodName", BINDING_FLAGS);
                methodNameField.SetValue(newCall, methodNameField.GetValue(call));

                FieldInfo modeField = persistentCallType.GetField("m_Mode", BINDING_FLAGS);
                modeField.SetValue(newCall, modeField.GetValue(call));

                FieldInfo callStateField = persistentCallType.GetField("m_CallState", BINDING_FLAGS);
                callStateField.SetValue(newCall, callStateField.GetValue(call));

                FieldInfo argumentsField = persistentCallType.GetField("m_Arguments", BINDING_FLAGS);
                var arguments = argumentsField.GetValue(call);
                Type argumentCacheType = arguments.GetType();
                var newArguments = Activator.CreateInstance(argumentCacheType);
                foreach(FieldInfo field in argumentCacheType.GetFields(BINDING_FLAGS))
                {
                    field.SetValue(newArguments, field.GetValue(arguments));
                }
                argumentsField.SetValue(newCall, newArguments);

                addMethod.Invoke(newPersistentCalls, new object[] { newCall });
            }

            MethodInfo dirtyPersistentCallsMethod = typeof(UnityEventBase).GetMethod("DirtyPersistentCalls", BINDING_FLAGS);

            dirtyPersistentCallsMethod.Invoke(newUdonEvent, null);

            MethodInfo rebuildPersistentCallsIfNeededMethod = typeof(UnityEventBase).GetMethod("RebuildPersistentCallsIfNeeded", BINDING_FLAGS);

            rebuildPersistentCallsIfNeededMethod.Invoke(newUdonEvent, null);

            return newUdonEvent;
        }

        public DataList ToDataList()
        {
            FieldInfo callGroupField = typeof(UnityEventBase).GetField("m_PersistentCalls", BINDING_FLAGS);

            var callGroup = callGroupField.GetValue(this);

            FieldInfo callsField = callGroup.GetType().GetField("m_Calls", BINDING_FLAGS);

            var persistentCalls = callsField.GetValue(callGroupField.GetValue(this));

            Type persistentCallType = persistentCalls.GetType().GetGenericArguments()[0];

            FieldInfo m_target = persistentCallType.GetField("m_Target", BINDING_FLAGS);
            FieldInfo m_MethodName = persistentCallType.GetField("m_MethodName", BINDING_FLAGS);
            FieldInfo m_Mode = persistentCallType.GetField("m_Mode", BINDING_FLAGS);
            FieldInfo m_Arguments = persistentCallType.GetField("m_Arguments", BINDING_FLAGS);

            Type argumentCacheType = m_Arguments.FieldType;

            FieldInfo m_ObjectArgument = argumentCacheType.GetField("m_ObjectArgument", BINDING_FLAGS);
            FieldInfo m_IntArgument = argumentCacheType.GetField("m_IntArgument", BINDING_FLAGS);
            FieldInfo m_FloatArgument = argumentCacheType.GetField("m_FloatArgument", BINDING_FLAGS);
            FieldInfo m_StringArgument = argumentCacheType.GetField("m_StringArgument", BINDING_FLAGS);
            FieldInfo m_BoolArgument = argumentCacheType.GetField("m_BoolArgument", BINDING_FLAGS);

            DataList data = new DataList();

            foreach (object call in persistentCalls as IEnumerable<object>)
            {
                PersistentListenerMode mode = (PersistentListenerMode)m_Mode.GetValue(call);

                var arguments = m_Arguments.GetValue(call);

                object target = m_target.GetValue(call);

                Type targetType = target.GetType();

                UdonEventResolver.Instance.TryResolveEventMethod(targetType, m_MethodName.GetValue(call).ToString(), out string methodAddress, out string targetAddress);

                object argument = GetMethodArgument(arguments, mode);

                if(argument == null)
                {
                    data.Add(new DataToken(new object[]
                    {
                        target,
                        targetAddress,
                        methodAddress
                    }));
                }
                else
                {
                    UdonEventResolver.Instance.TryResolveEventArgument(argument, out string argumentAddress);

                    data.Add(new DataToken(new object[]
                    {
                        target,
                        targetAddress,
                        methodAddress,
                        argument,
                        argumentAddress
                    }));
                }
            }

            object GetMethodArgument(object arguments, PersistentListenerMode mode)
            {
                switch (mode)
                {
                    case PersistentListenerMode.Void:
                        return null;
                    case PersistentListenerMode.Object:
                        return m_ObjectArgument.GetValue(arguments);
                    case PersistentListenerMode.Int:
                        return m_IntArgument.GetValue(arguments);
                    case PersistentListenerMode.Float:
                        return m_FloatArgument.GetValue(arguments);
                    case PersistentListenerMode.String:
                        return m_StringArgument.GetValue(arguments);
                    case PersistentListenerMode.Bool:
                        return m_BoolArgument.GetValue(arguments);
                    default:
                        return null;
                }
            }

            return data;
        }
#endif
    }
}

#endif
