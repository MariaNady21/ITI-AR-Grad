
using UnityEngine;

public class AudioManagerLoaderAndToggler : MonoBehaviour
{
    public AudioSource bgiossAudioSource; // ← اسحبيه من الـ Inspector

    void Awake()
    {
        if (AudioManager.instance == null)
        {
            GameObject prefab = Resources.Load<GameObject>("Sound Manger");
            if (prefab != null)
            {
                Instantiate(prefab);
                Debug.Log("📦 AudioManager Loaded from Resources");
            }
        }
    }

    public void ToggleSound()
    {
        // ✅ AudioManager toggle
        if (AudioManager.instance != null)
        {
            AudioManager.instance.ToggleMusic();
            Debug.Log("🎵 ToggleMusic called.");
        }

        // ✅ bgioss toggle (لو شغال)
        if (bgiossAudioSource != null)
        {
            if (bgiossAudioSource.isPlaying)
            {
                bgiossAudioSource.Pause();
                Debug.Log("🔇 bgioss Paused");
            }
            else
            {
                bgiossAudioSource.Play();
                Debug.Log("🔊 bgioss Resumed");
            }
        }
    }
}
