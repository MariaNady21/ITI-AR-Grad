using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void BackFromGame()
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.StopMusic();
            AudioManager.instance.GetSFXSource().Stop();
        }
        SceneManager.LoadScene(0);
    }

}