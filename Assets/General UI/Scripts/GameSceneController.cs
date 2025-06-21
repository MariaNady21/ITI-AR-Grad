using UnityEngine;

public class GameSceneController : MonoBehaviour
{
    public GameObject infoPanel;     // ������ ���� ����
    public GameObject[] gameElementsToHide;  // ������� ���� ����� �� ����� �� Info

    void Start()
    {
        if (SceneEntryMode.isInfoMode)
        {
            // ����� �� ���� Info
            infoPanel.SetActive(true);

            foreach (GameObject obj in gameElementsToHide)
            {
                obj.SetActive(false);
            }
        }
        else
        {
            // ����� �� ���� Play
            infoPanel.SetActive(false);
        }
    }
}
