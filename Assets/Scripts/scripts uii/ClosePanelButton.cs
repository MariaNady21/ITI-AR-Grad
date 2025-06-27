using UnityEngine;
using UnityEngine.SceneManagement;

public class ClosePanelButton : MonoBehaviour
{
    public GameObject winpanelToClose;

    public GameObject losepanelToClose;
    public void CloseWinPanel()
    {
        if (winpanelToClose != null)
        {
            winpanelToClose.SetActive(false); // Hides the panel
        }
    }


    public void CloseLosePanel()
    {
        if (losepanelToClose != null)
        {
            losepanelToClose.SetActive(false); // Hides the panel
        }
    }
<<<<<<< Updated upstream

    public void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        Vehicle.counter = 0;
        SceneManager.LoadScene(currentScene.buildIndex);
=======
    public void ReloadScene()
    {
       // Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene("car labs");
>>>>>>> Stashed changes

        if (!AudioManager.instance.GetComponent<AudioSource>().isPlaying)
        {
            AudioManager.instance.PlayMusic("IOT-BG");
        }
    }
    public void ToggleMusic()
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.ToggleMusic();
        }
    }
}
