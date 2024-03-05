using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Varneon.VUdon.UdonEvents.Editor
{
    public static class UdonEventBackupUtility
    {
        private const string LOG_PREFIX = "[<color=#ABC>VUdon</color>][<color=#ABCDEF>UdonEvents</color>]: ";

        private static UdonEventStorage[] GetAllStorages() => SceneManager.GetActiveScene()
            .GetRootGameObjects()
            .SelectMany(r => r.GetComponentsInChildren<UdonEventStorage>(true))
            .ToArray();

        [MenuItem("Varneon/VUdon/Events/Back Up Events")]
        public static void BackUpUdonEvents()
        {
            UdonEventStorage[] allStorages = GetAllStorages();

            foreach (UdonEventStorage storage in allStorages)
            {
                storage.BackUpEvents();
            }

            Debug.Log(string.Concat(LOG_PREFIX, "Backed up UdonEvents on ", allStorages.Length, " UdonSharpBehaviours!"));
        }

        [MenuItem("Varneon/VUdon/Events/Restore Events From Backup")]
        public static void RestoreUdonEvents()
        {
            UdonEventStorage[] allStorages = GetAllStorages();

            foreach (UdonEventStorage storage in allStorages)
            {
                storage.RestoreEventsFromBackup();
            }

            Debug.Log(string.Concat(LOG_PREFIX, "Restored UdonEvents on ", allStorages.Length, " UdonSharpBehaviours!"));
        }
    }
}
