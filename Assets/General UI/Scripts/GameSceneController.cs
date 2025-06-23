using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneController : MonoBehaviour
{
    public GameObject infoPanel;
    public GameObject[] gameElementsToHide;

    public void StartGame()
    {
        // Example: load the game scene
        SceneManager.LoadScene("whack a mole"); // Make sure this matches your scene name
    }

    public void ShowInfo()
    {
        infoPanel.SetActive(true);

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

