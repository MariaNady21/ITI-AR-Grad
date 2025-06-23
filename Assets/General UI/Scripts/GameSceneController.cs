using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneController : MonoBehaviour
{
    public GameObject infoPanel;
    public GameObject[] gameElementsToHide;
    AudioManager audioManager;
    void Start()
    {
        audioManager = AudioManager.instance;
       
    }
    public void StartGame()
    {
        SceneManager.LoadScene("whack a mole"); 
    }

    public void ShowInfo()
    {
        infoPanel.SetActive(true);
        audioManager.PlaySFX("INFO");
        audioManager.StopMusic();

        foreach (var element in gameElementsToHide)
        {
            element.SetActive(false);
        }
    }

    public void HideInfo()
    {
        infoPanel.SetActive(false);

        foreach (var element in gameElementsToHide)
        {
            element.SetActive(true);
        }
    }
}

