using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadGameSceneFromPlay : MonoBehaviour
{
    public string clickSoundName;

    public void LoadSceneGame()
    {
        StartCoroutine(PlaySoundAndLoadScene(3));
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
        yield return new WaitForSeconds(0.5f); //  √ŒÌ— »”Ìÿ ﬁ»· «·‰ﬁ· ··„‘Âœ
        SceneManager.LoadScene(sceneIndex);
    }

    public void LoadSceneIOT()
    {
        SceneEntryMode.isInfoMode = false;
        SceneManager.LoadScene(2);
    }

    public void LoadSceneEmbedded()
    {
        SceneEntryMode.isInfoMode = false;
        SceneManager.LoadScene(4);
    }

}

