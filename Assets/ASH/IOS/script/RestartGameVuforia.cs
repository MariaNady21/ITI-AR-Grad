using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGameVuforia : MonoBehaviour
{

    public string sceneName; // ����� ��� ��� ������ ���� ����� �����

    public void LoadSceneByName()
    {
        SceneManager.LoadScene(1);
    }
}
