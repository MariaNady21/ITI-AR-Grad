using UnityEngine;

public class PartSwitcher : MonoBehaviour
{
    [SerializeField] GameObject infoPanel;
    [SerializeField] GameObject[] gameElementsToHide;
    AudioManager audioManager;

    void Start()
    {
        audioManager = AudioManager.instance;
        if (SceneEntryMode.isInfoMode)
        {
            infoPanel.SetActive(true);
           
            AudioManager.instance.StopMusic();

            foreach (GameObject obj in gameElementsToHide)
                obj.SetActive(false);

            
           
        }
        else
        {
            audioManager.GetSFXSource().Stop();
            infoPanel.SetActive(false);

            foreach (GameObject obj in gameElementsToHide)
                obj.SetActive(true);

           
        }
    }
}