using UnityEngine;

public class GameSceneController : MonoBehaviour
{
    public GameObject infoPanel;     // «·»«‰· «··Ì ÌŸÂ—
    public GameObject[] gameElementsToHide;  // «·⁄‰«’— «··Ì   Œ›Ì ·Ê œŒ·‰« „‰ Info

    void Start()
    {
        if (SceneEntryMode.isInfoMode)
        {
            // Ã«ÌÌ‰ „‰ “—«— Info
            infoPanel.SetActive(true);

            foreach (GameObject obj in gameElementsToHide)
            {
                obj.SetActive(false);
            }
        }
        else
        {
            // Ã«ÌÌ‰ „‰ “—«— Play
            infoPanel.SetActive(false);
        }
    }
}
