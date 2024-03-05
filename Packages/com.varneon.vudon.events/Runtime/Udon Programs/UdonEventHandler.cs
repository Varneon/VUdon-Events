using JetBrains.Annotations;
using UdonSharp;
using UnityEngine;
using VRC.SDK3.Data;

namespace Varneon.VUdon.UdonEvents
{
    /// <summary>
    /// Singleton handler for UdonEvents
    /// </summary>
    [AddComponentMenu("")]
    [ExcludeFromPreset]
    [DisallowMultipleComponent]
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    public partial class UdonEventHandler : UdonSharpBehaviour
    {
#pragma warning disable IDE0052 // Variables required for preventing U# from generating redundant internal symbols
        private object _dump;

        private bool _overloadCheck;
#pragma warning restore IDE0052

        /// <summary>
        /// Current invokation target
        /// </summary>
        private Object _target;

        /// <summary>
        /// Full type name of the invokation target
        /// </summary>
        /// <remarks>
        /// All periods ('.') have been replaced with underscores ('_')
        /// </remarks>
        private string _targetTypeName;

        /// <summary>
        /// Address of the method to be invoked
        /// </summary>
        private string _methodAddress;

        /// <summary>
        /// Argument to pass into the method to be invoked
        /// </summary>
        private object _argument;

        /// <summary>
        /// Type name of the method argument
        /// </summary>
        private string _argumentTypeName;

        private const string
            T_BOOLEAN = "Boolean",
            T_INT32 = "Int32",
            T_CUBEMAP = "Cubemap",
            T_RENDERTEXTURE = "RenderTexture";

        private const string LOG_PREFIX = "[<color=#ABC>VUdon</color>][<color=#ABCDEF>UdonEvents</color>] ";

        private const string WARNING_TEMPLATE_NULL_TARGET = "Call target for method '<color=#FEDCBA>{0}</color>' was null!";

        /// <summary>
        /// Invokes a list of calls on an event
        /// </summary>
        /// <remarks>
        /// DataList should originate from the serialized field with [UdonEvent] attribute on it
        /// </remarks>
        /// <param name="eventCalls"></param>
        [PublicAPI]
        public void Invoke(DataList eventCalls)
        {
            // Iterate through all of the persistent calls on the UdonEvent
            foreach(DataToken e in eventCalls.ToArray())
            {
                // Get the serialized data on the persistent call
                object[] callData = (object[])e.Reference;

                // Check if target is valid
                if(_target = (Object)callData[0])
                {
                    _targetTypeName = (string)callData[1];
                    _methodAddress = (string)callData[2];

                    // (Ab)use SetProgramVariable to force target to the reserved target symbol of corresponding type
                    SetProgramVariable(_targetTypeName, _target);

                    // Does the call have an argument
                    if (callData.Length > 3)
                    {
                        _argument = callData[3];
                        _argumentTypeName = (string)callData[4];

                        // If the call has an argument, forward the argument to the reserved argument symbol of corresponding type
                        SetProgramVariable(_argumentTypeName, _argument);
                    }

                    // Invoke the method
                    SendCustomEvent(_methodAddress);
                }
                else // If call target was null, warn user about it
                {
                    LogWarning(string.Format(WARNING_TEMPLATE_NULL_TARGET, callData[2]));
                }
            }
        }

        private void LogWarning(string message)
        {
            Debug.LogWarning(string.Concat(LOG_PREFIX, message));
        }
    }
}
