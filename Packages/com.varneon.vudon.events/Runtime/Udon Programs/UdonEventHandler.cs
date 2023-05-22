using JetBrains.Annotations;
using System;
using UdonSharp;
using UnityEngine;
using VRC.SDK3.Data;

namespace Varneon.VUdon.UdonEvents
{
    using Object = UnityEngine.Object;

    /// <summary>
    /// Singleton handler for UdonEvents
    /// </summary>
    [AddComponentMenu("")]
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    public partial class UdonEventHandler : UdonSharpBehaviour
    {
        private Object _target;

        private object _argument;

        private UdonEventListenerMode _mode;

        private const string LOG_PREFIX = "<color=#ABCDEF>[UdonEvents]</color> ";

        /// <summary>
        /// Invokes a method on an object
        /// </summary>
        /// <param name="target"></param>
        /// <param name="methodName"></param>
        /// <param name="mode"></param>
        /// <param name="argument"></param>
        [PublicAPI]
        public void Invoke(Object target, string methodName, UdonEventListenerMode mode, object argument)
        {
            if(target == null)
            {
                LogWarning(string.Concat("Call target for method '<color=#FEDCBA>", methodName, "</color>' was null!"));

                return;
            }

            Type targetType = target.GetType();

            if(typeMethodTree.TryGetValue(targetType.FullName, out DataToken methodTreeToken))
            {
                if(((DataDictionary)methodTreeToken).TryGetValue(methodName, out DataToken methodIndexToken))
                {
                    _target = target;

                    _mode = mode;

                    _argument = argument;

                    string methodProxyName = string.Concat("_", methodIndexToken.String);

                    SendCustomEvent(methodProxyName);
                }
                else
                {
                    LogWarning(string.Concat("The method '<color=#FEDCBA>", methodName, "</color>' on '<color=#FEDCBA>", targetType.FullName, "</color>' is not exposed to Udon!"));
                }
            }
            else
            {
                LogWarning(string.Concat("The type '<color=#FEDCBA>", targetType.FullName, "</color>' doesn't have any exposed methods!"));
            }
        }

        /// <summary>
        /// Invokes a list of calls on an event
        /// </summary>
        /// <param name="eventCalls"></param>
        [PublicAPI]
        public void Invoke(DataList eventCalls)
        {
            foreach(DataToken e in eventCalls.ToArray())
            {
                object[] callData = (object[])e.Reference;

                Invoke((Object)callData[0], (string)callData[1], (UdonEventListenerMode)callData[2], callData[3]);
            }
        }

        private void LogWarning(string message)
        {
            Debug.LogWarning(string.Concat(LOG_PREFIX, message));
        }
    }
}
