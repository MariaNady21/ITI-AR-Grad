using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGameSceneFromPlay : MonoBehaviour
{
    public void LoadScene()
    {
        SceneEntryMode.isInfoMode = false;
        SceneManager.LoadScene(3);
    }
}
