using UnityEngine;

public class SimpleAudioController : MonoBehaviour
{

    public AudioSource audioSource;

    void Start()
    {
        //  Õ„Ì· Õ«·… «·’Ê  ⁄‰œ «·»œ«Ì…
        audioSource.mute = PlayerPrefs.GetInt("Muted", 0) == 1;
    }

    public void OnToggleSound()
    {
        audioSource.mute = !audioSource.mute;
        PlayerPrefs.SetInt("Muted", audioSource.mute ? 1 : 0);
        PlayerPrefs.Save();
    }
}
