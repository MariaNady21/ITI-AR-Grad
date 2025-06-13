using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerUI : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("GAMEIOS"); // €Ì— «”„ «·„‘Âœ ·Ê ·«“„
    }

    public void ToggleAudio()
    {
       /* if (AudioManager.instance != null)
        {
            AudioManager.instance.ToggleMute();
        }*/
    }

    public void QuitGame()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
