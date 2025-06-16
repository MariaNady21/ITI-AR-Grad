using UnityEngine;

public class BGSoundStarterios : MonoBehaviour
{
    void Start()
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.PlayMusic("bg ios main");
        }
        else
        {
            Debug.LogWarning("AudioManager not found in scene!");
        }
    }
}
