using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneDelayLoader_2 : MonoBehaviour
{
    [SerializeField] private GameObject delayPanel;
    [SerializeField] private GameObject panelToHide;
    [SerializeField] private float delayTime = 15f;  // „„ﬂ‰  Œ·ÌÂ „Œ ·›
    [SerializeField] private int sceneIndex = 4;     // «·„‘Âœ «·ÃœÌœ

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

