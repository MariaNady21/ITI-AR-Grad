using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneDelayLoader : MonoBehaviour
{
    [SerializeField] private GameObject delayPanel;    // ������ ���� ���� ������ (HELP)
    [SerializeField] private GameObject panelToHide;   // ������ ������ (���� ��� ������)
    [SerializeField] private float delayTime = 10f;
    [SerializeField] private int sceneIndex;

    public void OnButtonClick()
    {
        panelToHide.SetActive(false);   // ����� ������ �����
        delayPanel.SetActive(true);     // ����� ���� HELP
        StartCoroutine(WaitAndLoadScene());
    }

    private IEnumerator WaitAndLoadScene()
    {
        yield return new WaitForSeconds(delayTime);
        SceneManager.LoadScene(sceneIndex);
    }
}
