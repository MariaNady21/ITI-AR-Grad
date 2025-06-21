using UnityEngine;

public class BGSoundStarterios : MonoBehaviour
{
 
    void Start()
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.PlayMusic("bg ios main");
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
