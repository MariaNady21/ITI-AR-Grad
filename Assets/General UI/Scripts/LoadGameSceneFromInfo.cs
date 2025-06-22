using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadGameSceneFromInfo : MonoBehaviour
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
        SceneEntryMode.isInfoMode = true;
        AudioManager.instance.PlaySFX(clickSoundName);
        yield return new WaitForSeconds(0.5f); // ����� ���� ��� ����� ������
        SceneManager.LoadScene(sceneIndex);
    }
}
