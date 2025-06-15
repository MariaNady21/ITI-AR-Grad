// [UI03] Sound Toggle – Mute/Unmute all game audio
using UnityEngine;

public class ToggleSound : MonoBehaviour
{
    private bool isMuted = false;

   /* public void ToggleAudio()
    {
        isMuted = !isMuted;

        if (FindObjectOfType<AudioManager>() != null)
        {
            FindObjectOfType<AudioManager>().SetMute(isMuted);
        }
        else
        {
            AudioListener.volume = isMuted ? 0 : 1;
        }
    }*/
}
