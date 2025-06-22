using UnityEngine;

public class ClosePanelButton : MonoBehaviour
{
    public GameObject winpanelToClose;

    public GameObject losepanelToClose;
    public void CloseWinPanel()
    {
        if (winpanelToClose != null)
        {
            winpanelToClose.SetActive(false); // Hides the panel
        }
    }


    public void CloseLosePanel()
    {
        if (losepanelToClose != null)
        {
            losepanelToClose.SetActive(false); // Hides the panel
        }
    }
}
