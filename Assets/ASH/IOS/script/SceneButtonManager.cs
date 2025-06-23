using UnityEngine;

public class MuteAllByName : MonoBehaviour
{
    public string clipNameToMute = "bgioss"; // «”„ «·’Ê  »«·Ÿ»ÿ “Ì „« „ﬂ Ê» ›Ì Audio Clip
    private bool isMuted;

    public void ToggleMute()
    {
        isMuted = !isMuted;
        PlayerPrefs.SetInt("Muted", isMuted ? 1 : 0);
        PlayerPrefs.Save();

        ApplyMute();
    }

    void Start()
    {
        isMuted = PlayerPrefs.GetInt("Muted", 0) == 1;
        ApplyMute();
    }

    void ApplyMute()
    {
        AudioSource[] allSources = FindObjectsOfType<AudioSource>();
        foreach (AudioSource src in allSources)
        {
            if (src.clip != null && src.clip.name == clipNameToMute)
            {
                src.mute = isMuted;
            }
        }
    }
}
