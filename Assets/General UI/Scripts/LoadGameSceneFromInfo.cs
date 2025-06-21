using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGameSceneFromInfo : MonoBehaviour
{
    public void LoadScene()
    {
        SceneEntryMode.isInfoMode = true;
        SceneManager.LoadScene(3);
    }
}
