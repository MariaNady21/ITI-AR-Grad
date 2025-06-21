using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSoundToggler : MonoBehaviour
{
    public AudioSource bgiossAudioSource; // اسحبيه من Inspector لو أنتِ في مشهد GAMEIOS

    public void ToggleSound()
    {
        string sceneName = SceneManager.GetActiveScene().name;

        if (sceneName == "iosui")
        {
            if (AudioManager.instance != null)
            {
                AudioManager.instance.ToggleMusic();
                Debug.Log("🎵 iosui → ToggleMusic from AudioManager");
            }
            else
            {
                Debug.LogWarning("❌ AudioManager مش موجود في iosui");
            }
        }
        else if (sceneName == "GAMEIOS")
        {
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
                    Debug.Log("🔊 bgioss Played");
                }
            }
            else
            {
                Debug.LogWarning("⚠️ مفيش AudioSource مسحوب اسمه bgioss!");
            }
        }
        else
        {
            Debug.Log($"ℹ️ المشهد الحالي ({sceneName}) مفيهوش صوت نتحكم فيه");
        }
    }
}
