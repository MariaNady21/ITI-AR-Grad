using UnityEngine;
using UnityEngine.SceneManagement;

public class ShowPanelOnClick : MonoBehaviour
{
    public GameObject panelToShow;

    public GameObject[] objectsToHide; // ·Ê ⁄«Ì“…  Œ›Ì ⁄‰«’—  «‰Ì…

    public void ShowPanel()
    {
    
        SceneManager.LoadScene(3);
    
    
        //SceneManager.LoadScene(0);
    

        panelToShow.SetActive(true);

        foreach (GameObject obj in objectsToHide)
        {
            obj.SetActive(false);
        }
    }
}
