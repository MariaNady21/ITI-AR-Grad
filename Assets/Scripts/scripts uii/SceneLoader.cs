using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void BackFromGame()
    {
        SceneManager.LoadScene(0);
    }

}