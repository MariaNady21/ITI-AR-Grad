using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneDelayLoader : MonoBehaviour
{
    [SerializeField] private GameObject delayPanel;    // «·»«‰· «··Ì ›ÌÂ« «·’Ê—… (HELP)
    [SerializeField] private GameObject panelToHide;   // «·»«‰· «·ﬁœÌ„ («··Ì ›ÌÂ «·“—«—)
    [SerializeField] private float delayTime = 10f;
    [SerializeField] private int sceneIndex;

    public void OnButtonClick()
    {
        panelToHide.SetActive(false);   // ≈Œ›«¡ «·»«‰· «·√Ê·
        delayPanel.SetActive(true);     // ≈ŸÂ«— »«‰· HELP
        StartCoroutine(WaitAndLoadScene());
    }

    private IEnumerator WaitAndLoadScene()
    {
        yield return new WaitForSeconds(delayTime);
        SceneManager.LoadScene(sceneIndex);
    }
}
