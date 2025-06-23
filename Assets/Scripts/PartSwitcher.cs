using UnityEngine;

public class PartSwitcher : MonoBehaviour
{
    public GameObject Game;
    public GameObject INFO;

    public string GameSoundName = "background";
    public string InfoSoundName = "info";

    private void StopAllSounds()
    {
        AudioSource[] allAudio = FindObjectsOfType<AudioSource>();
        foreach (AudioSource audio in allAudio)
        {
            audio.Stop();
        }
    }

    private void PlaySoundByName(string name)
    {
        AudioSource[] allAudio = FindObjectsOfType<AudioSource>();
        foreach (AudioSource audio in allAudio)
        {
            if (audio.clip != null && audio.clip.name == name)
            {
                audio.Play();
                break;
            }
        }
    }

    public void ShowPartA()
    {
        Game.SetActive(true);
        INFO.SetActive(false);

        StopAllSounds();
        PlaySoundByName(GameSoundName);
    }

    public void ShowPartB()
    {
        Game.SetActive(false);
        INFO.SetActive(true);

        StopAllSounds();
        PlaySoundByName(InfoSoundName);
    }
}