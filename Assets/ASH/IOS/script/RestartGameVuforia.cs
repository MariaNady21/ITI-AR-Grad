using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGameVuforia : MonoBehaviour
{

    public string sceneName; // ÇßÊÈí åäÇ ÇÓã ÇáãÔåÏ Çááí ÚÇíÒÉ íÔÊÛá

    public void LoadSceneByName()
    {
        SceneManager.LoadScene(1);
    }
}
