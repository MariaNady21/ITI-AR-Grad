using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    //---------------------------------------------
    // Function to Load Scene 0
    public void LoadSceneIOSui()
    {
        SceneManager.LoadScene(9);
    }

    //---------------------------------------------
    // Function to Load Scene 1
    public void LoadSceneIOSgame()
    {
        SceneManager.LoadScene(1);
    }

    public void BackFromGame()
    {
        SceneManager.LoadScene(0);
    }
    public void BackFromIOSGame()
    {
        SceneManager.LoadScene(0);
    }


    //---------------------------------------------
    // Function to Load Scene 2
    public void LoadSceneIOTGame()
    {
        SceneManager.LoadScene(2);
    }

    //---------------------------------------------
    // Function to Load Scene 3
    public void LoadScenegallery()
    {
        SceneManager.LoadScene(5);
    }


    public void BackFromIOTGame()
    {
        SceneManager.LoadScene(2);
    }
   


    //---------------------------------------------
    // Function to Load Scene 4
    public void LoadSceneXRGame()
    {
        SceneManager.LoadScene(3);
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
        SceneManager.LoadScene(4);
    }

    //---------------------------------------------
    // Function to Load Scene 0
    public void LoadSceneEmbeddedui()
    {
        SceneManager.LoadScene(55);
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