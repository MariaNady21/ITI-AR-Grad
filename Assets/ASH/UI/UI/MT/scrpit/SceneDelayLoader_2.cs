using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneDelayLoader_2 : MonoBehaviour
{
    [SerializeField] private GameObject delayPanel;
    [SerializeField] private GameObject panelToHide;
    [SerializeField] private float delayTime = 15f;  // ���� ����� �����
    [SerializeField] private int sceneIndex = 4;     // ������ ������

    public void OnButtonClick()
    {
        panelToHide.SetActive(false);
        delayPanel.SetActive(true);
        StartCoroutine(WaitAndLoadScene());
    }

    private IEnumerator WaitAndLoadScene()
    {
        yield return new WaitForSeconds(delayTime);
        SceneManager.LoadScene(sceneIndex);
    }
}

