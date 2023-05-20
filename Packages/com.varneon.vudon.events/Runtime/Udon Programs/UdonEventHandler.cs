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
            //Debug.Log(string.Concat(LOG_PREFIX, "Invoke(", target, ",", methodName, ",", mode.ToString(), ",", argument, ")"));

            Type targetType = target.GetType();

            _target = target;

            _mode = mode;

            _argument = argument;

            string typeName = targetType.FullName.Replace('.', '_');

            string methodProxy = string.Concat(typeName, "__", methodName);

            SendCustomEvent(methodProxy);
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
    }
}
