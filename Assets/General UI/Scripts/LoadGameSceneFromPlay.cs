using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadGameSceneFromPlay : MonoBehaviour
{
    private string clickSoundName;
    AudioManager audioManager;

    public void LoadSceneGame()
    {
        StartCoroutine(PlaySoundAndLoadScene(3));
        AudioManager.instance.PlayMusic("BackGround");
    }

    public void LoadSceneGallery()
    {
        StartCoroutine(PlaySoundAndLoadScene(5));
    }

    public void LoadSceneIOS()
    {
        StartCoroutine(PlaySoundAndLoadScene(1));
    }

    IEnumerator PlaySoundAndLoadScene(int sceneIndex)
    {
        SceneEntryMode.isInfoMode = false;
        AudioManager.instance.PlaySFX(clickSoundName);
        yield return new WaitForSeconds(0.5f);
      

        SceneManager.LoadScene(sceneIndex);
    }

    public void LoadSceneIOT()
    {
        SceneEntryMode.isInfoMode = false;
        SceneManager.LoadScene(2);
        AudioManager.instance.PlayMusic("bg emb");
    }

    public void LoadSceneEmbedded()
    {
        SceneEntryMode.isInfoMode = false;
        SceneManager.LoadScene(4);
        
        AudioManager.instance.PlayMusic("bg emb");
    }

}

