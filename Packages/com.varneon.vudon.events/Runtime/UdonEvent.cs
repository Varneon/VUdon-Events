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
        private const BindingFlags BINDING_FLAGS = BindingFlags.Instance | BindingFlags.NonPublic;

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

                data.Add(new DataToken(new object[]
                {
                    m_target.GetValue(call),
                    m_MethodName.GetValue(call),
                    (int)mode,
                    GetMethodArgument(arguments, mode)
                }));
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
    }
}
