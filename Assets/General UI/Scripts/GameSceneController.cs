using UnityEngine;

public class GameSceneController : MonoBehaviour
{
    [Header("Info Mode Elements")]
    public GameObject infoPanel;
    public GameObject[] gameElementsToHide;

    [Header("Audio Settings")]
    public AudioSource audioSource;
    public AudioClip infoClip;
    public AudioClip gameClip;

    void Start()
    {
        if (SceneEntryMode.isInfoMode)
        {
            // Show info panel
            infoPanel.SetActive(true);

            // Hide gameplay objects
            foreach (GameObject obj in gameElementsToHide)
                obj.SetActive(false);

            // Stop any background sound (like bgioss)
            StopAudioByClipName("bgioss");

            // Play info audio
            audioSource.Stop();
            audioSource.loop = false;
            audioSource.clip = infoClip;
            audioSource.Play();
        }
        else
        {
            // Hide info panel
            infoPanel.SetActive(false);

            // Stop any background sound (like bgioss)
            StopAudioByClipName("bgioss");

            // Play game background audio
            audioSource.Stop();
            audioSource.loop = true;
            audioSource.clip = gameClip;
            audioSource.Play();
        }
    }

    void Update()
    {
        if (audioSource.isPlaying)
        {
            string currentClipName = audioSource.clip.name.ToLower();

            // If win/lose sound is playing → stop bg/info if still playing
            if (currentClipName == "i win" || currentClipName == "game-over")
            {
                StopAudioByClipName("bgioss");
                StopAudioByClipName("info");
            }
        }
    }

    // Stop any audio source playing a clip with the given name
    void StopAudioByClipName(string clipName)
    {
        AudioSource[] allSources = FindObjectsOfType<AudioSource>();

        foreach (AudioSource src in allSources)
        {
            if (src.isPlaying && src.clip != null && src.clip.name.ToLower() == clipName.ToLower())
            {
                src.Stop();
            }
        }
    }
}
