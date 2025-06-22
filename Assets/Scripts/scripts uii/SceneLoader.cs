using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void BackFromGame()
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.StopMusic(); 
        }
        SceneManager.LoadScene(0);
    }

}