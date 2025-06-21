using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGameVuforia : MonoBehaviour
{
    public string sceneName;

    public AudioSource bgiossAudioSource;

    public void LoadSceneByName()
    {
        // 🛑 وقف صوت الخلفية لو شغال
        if (bgiossAudioSource != null && bgiossAudioSource.isPlaying)
        {
            bgiossAudioSource.Stop();
            Debug.Log("🎵 bgioss stopped قبل ما نعيد المشهد");
        }

        // 🛑 وقف كل الأصوات من AudioManager
        if (AudioManager.instance != null)
        {
            AudioManager.instance.GetSFXSource().Stop();
            Debug.Log("🔇 كل الأصوات اتقفلت من AudioManager");
        }

        // 🔁 إعادة تحميل المشهد
        SceneManager.LoadScene(2);
    }
}
