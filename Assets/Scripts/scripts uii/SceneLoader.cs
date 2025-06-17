using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    //---------------------------------------------
    // Function to Load Scene 0
    public void LoadSceneIOSGame()
    {
        SceneManager.LoadScene(5);
    }

    //---------------------------------------------
    // Function to Load Scene 1
    public void LoadSceneIOSInfo()
    {
        SceneManager.LoadScene(6);
    }

    public void BackFromIOSGame()
    {
        SceneManager.LoadScene(1);
    }



    //---------------------------------------------
    // Function to Load Scene 2
    public void LoadSceneIOTGame()
    {
        SceneManager.LoadScene(8);
    }

    //---------------------------------------------
    // Function to Load Scene 3
    public void LoadSceneIOTInfo()
    {
        SceneManager.LoadScene(9);
    }


    public void BackFromIOTGame()
    {
        SceneManager.LoadScene(2);
    }



    //---------------------------------------------
    // Function to Load Scene 4
    public void LoadSceneXRGame()
    {
        SceneManager.LoadScene(7);
    }
    public void BackFromXRGame()
    {
        SceneManager.LoadScene(0);
    }




    //---------------------------------------------
    // Function to Load Scene 5
    public void LoadSceneXRInfo()
    {
        SceneManager.LoadScene(16);
    }

    //---------------------------------------------
    // Function to Load Scene 6
    public void LoadSceneEmbeddedGame()
    {
        SceneManager.LoadScene(11);
    }

    //---------------------------------------------
    // Function to Load Scene 7
    public void LoadSceneEmbeddedInfo()
    {
        SceneManager.LoadScene(10);
    }
    public void BackFromEmbeddedGame()
    {
        SceneManager.LoadScene(3);
    }

    //---------------------------------------------
    // Function to Load Scene 8
    public void LoadSceneGalleryGame()
    {
        SceneManager.LoadScene(8);
    }

    //---------------------------------------------
    // Function to Load Scene 9
    public void LoadSceneGalleryInfo()
    {
        SceneManager.LoadScene(9);
    }
}