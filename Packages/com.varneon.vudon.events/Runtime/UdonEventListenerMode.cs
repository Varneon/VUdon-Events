namespace Varneon.VUdon.UdonEvents
{
    /// <summary>
    /// The argument type that will be used for the UdonEvent listener
    /// </summary>
    public enum UdonEventListenerMode
    {
        /// <summary>
        /// The listener will use the function binding specified by the event.
        /// </summary>
        EventDefined,
        /// <summary>
        /// The listener will bind to zero argument functions.
        /// </summary>
        Void,
        /// <summary>
        /// The listener will bind to one argument Object functions.
        /// </summary>
        Object,
        /// <summary>
        /// The listener will bind to one argument int functions.
        /// </summary>
        Int,
        /// <summary>
        /// The listener will bind to one argument float functions.
        /// </summary>
        Float,
        /// <summary>
        /// The listener will bind to one argument string functions.
        /// </summary>
        String,
        /// <summary>
        /// The listener will bind to one argument bool functions.
        /// </summary>
        Bool
    }
}
