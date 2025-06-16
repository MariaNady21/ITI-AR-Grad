using UnityEngine;

public class BGMusicStarter : MonoBehaviour
{
    void Start()
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.PlayMusic("BackGround");
        }
    }

    void OnDisable()
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.StopMusic();
        }
    }

    void OnDestroy()
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.StopMusic();
        }
    }
}
