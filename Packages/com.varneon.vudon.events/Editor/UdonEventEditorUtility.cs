using JetBrains.Annotations;
using UdonSharpEditor;
using UnityEngine;

namespace Varneon.VUdon.UdonEvents.Editor
{
    public static class UdonEventEditorUtility
    {
        private static UdonEventHandler eventHandler;

        /// <summary>
        /// Finds or creates a <see cref="UdonEventHandler"/> singleton in the scene
        /// </summary>
        /// <returns><see cref="UdonEventHandler"/> singleton instance</returns>
        [PublicAPI]
        public static UdonEventHandler GetOrAddUdonEventHandler()
        {
            // Try returning cached or found instance of the event handler
            if (eventHandler || (eventHandler = Object.FindObjectOfType<UdonEventHandler>(true))) { return eventHandler; }

            // Create a new instance if one couldn't be found in the scene
            eventHandler = new GameObject(nameof(UdonEventHandler)).AddUdonSharpComponent<UdonEventHandler>();

            // Disable all synchronization on the UdonBehaviour
            UdonSharpEditorUtility.GetBackingUdonBehaviour(eventHandler).SyncMethod = VRC.SDKBase.Networking.SyncType.None;

            return eventHandler;
        }
    }
}
