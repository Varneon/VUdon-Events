using UnityEngine;

namespace Varneon.VUdon.UdonEvents
{
    public class UdonEventDataAttribute : PropertyAttribute
    {
        public readonly string EventDataFieldName;

        public UdonEventDataAttribute(string eventDataFieldName)
        {
            EventDataFieldName = eventDataFieldName;
        }
    }
}
