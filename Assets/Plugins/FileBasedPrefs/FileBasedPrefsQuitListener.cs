using UnityEngine;

namespace Plugins.FileBasedPrefs
{
    public class FileBasedPrefsQuitListener : MonoBehaviour
    {
        public static FileBasedPrefsQuitListener Instance;

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        private void OnApplicationFocus(bool hasFocus)
        {
            FileBasedPrefs.ManuallySave();
        }

        private void OnApplicationPause(bool pauseStatus)
        {
            FileBasedPrefs.ManuallySave();
        }

        private void OnApplicationQuit()
        {
            FileBasedPrefs.ManuallySave();
        }
    }
}