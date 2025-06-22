using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGameSceneFromInfo : MonoBehaviour
{
    public void LoadSceneGame()
    {
        SceneEntryMode.isInfoMode = true;
        SceneManager.LoadScene(3);
    }

    public void LoadSceneGallery()
    {
        SceneEntryMode.isInfoMode = true;
        SceneManager.LoadScene(5);
    }

    public void LoadSceneIOS()
    {
        SceneEntryMode.isInfoMode = true;
        SceneManager.LoadScene(1);
    }

    public void LoadSceneIOT()
    {
        SceneEntryMode.isInfoMode = true;
        SceneManager.LoadScene(2);
    }

    public void LoadSceneEmbedded()
    {
        SceneEntryMode.isInfoMode = true;
        SceneManager.LoadScene(4);
    }

}
