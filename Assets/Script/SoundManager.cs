using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;

    void Awake()
    {
        // Check if an instance of SoundManager already exists
        if (instance != null)
        {
            // If an instance already exists, destroy this one
            Destroy(gameObject);
            return;
        }

        // Set this instance as the singleton instance
        instance = this;

        // Keep this SoundManager object between scenes
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        // Ensure that there is only one active Audio Listener in the scene
        AudioListener[] audioListeners = FindObjectsOfType<AudioListener>();
        if (audioListeners.Length > 1)
        {
            // Deactivate all Audio Listeners except for the first one found
            for (int i = 1; i < audioListeners.Length; i++)
            {
                Destroy(audioListeners[i]);
            }
        }
    }

    // Your other sound management methods can go here
}
