using UnityEngine;

public class GameSceneController : MonoBehaviour
{
    public GameObject infoPanel;
    public GameObject[] gameElementsToHide;

    public AudioSource audioSource;
    public AudioClip infoClip;
    public AudioClip gameClip;

    void Start()
    {
        if (SceneEntryMode.isInfoMode)
        {
            infoPanel.SetActive(true);

            foreach (GameObject obj in gameElementsToHide)
                obj.SetActive(false);

            //  √ﬂœ ≈‰ «·’Ê  »Ì‘ €· »‘ﬂ· ‰ŸÌ›
            audioSource.Stop();
            audioSource.clip = infoClip;
            audioSource.Play();
        }
        else
        {
            infoPanel.SetActive(false);

            audioSource.Stop();
            audioSource.clip = gameClip;
            audioSource.Play();
        }
    }
}

