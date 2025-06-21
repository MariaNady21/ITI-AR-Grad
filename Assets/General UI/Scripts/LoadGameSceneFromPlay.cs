using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGameSceneFromPlay : MonoBehaviour
{
    public void LoadSceneGame()
    {
        SceneEntryMode.isInfoMode = false;
        SceneManager.LoadScene(3);
    }

    public void LoadSceneGallery()
    {
        SceneEntryMode.isInfoMode = false;
        SceneManager.LoadScene(5);
    }

    public void LoadSceneIOS()
    {
        SceneEntryMode.isInfoMode = false;
        SceneManager.LoadScene(1);
    }
}
