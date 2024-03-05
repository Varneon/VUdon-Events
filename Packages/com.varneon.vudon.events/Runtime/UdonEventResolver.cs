#if UNITY_EDITOR && !COMPILER_UDONSHARP

using Newtonsoft.Json.Linq;
using System;
using UnityEditor;
using UnityEngine;

namespace Varneon.VUdon.UdonEvents
{
    public class UdonEventResolver
    {
        private static JObject methodsJson;

        private static JObject targetsJson;

        private static JObject argumentsJson;

        private const string ADDRESS_LOOKUP_PATH = "Packages/com.varneon.vudon.events/Runtime/UdonEventAddressLookup.json";

        private const string LOG_PREFIX = "[<color=#ABC>VUdon</color>][<color=#ABCDEF>UdonEvents</color>] ";

        public static UdonEventResolver Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UdonEventResolver();

                    JObject json = JObject.Parse(AssetDatabase.LoadAssetAtPath<TextAsset>(ADDRESS_LOOKUP_PATH).text);

                    methodsJson = (JObject)json["methods"];

                    targetsJson = (JObject)json["targets"];

                    argumentsJson = (JObject)json["arguments"];
                }

                return instance;
            }
        }

        private static UdonEventResolver instance;

        public bool TryResolveEventMethod(Type type, string method, out string resolvedMethod, out string resolvedTargetAddress)
        {
            bool resolved = false;

            resolvedMethod = string.Empty;

            resolvedTargetAddress = string.Empty;

            if (type == null || string.IsNullOrWhiteSpace(method)) { return resolved; }

            string targetTypeFullName = type.FullName;

            if (methodsJson.TryGetValue(targetTypeFullName, out JToken typeContainerToken))
            {
                if (((JObject)typeContainerToken).TryGetValue(method, out JToken methodAddressToken))
                {
                    resolvedMethod = string.Concat("_", methodAddressToken.ToString());

                    resolved = true;

                    resolvedTargetAddress = (string)targetsJson[type.Name];
                }
                else
                {
                    LogWarning(string.Concat("The method '<color=#FEDCBA>", method, "</color>' on '<color=#FEDCBA>", targetTypeFullName, "</color>' is not exposed to Udon!"));
                }
            }
            else
            {
                LogWarning(string.Concat("The type '<color=#FEDCBA>", targetTypeFullName, "</color>' doesn't have any exposed methods!"));
            }

            return resolved;
        }

        public bool TryResolveEventArgument(object argument, out string resolvedArgumentAddress)
        {
            bool resolved = false;

            resolvedArgumentAddress = string.Empty;

            if(argument == null) { return resolved; }

            if(argumentsJson.TryGetValue(argument.GetType().Name, out JToken argumentAddressToken))
            {
                resolvedArgumentAddress = (string)argumentAddressToken;
            }

            return resolved;
        }

        private void LogWarning(string message)
        {
            Debug.LogWarning(string.Concat(LOG_PREFIX, message));
        }
    }
}

#endif
