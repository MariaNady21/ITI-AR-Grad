using UnityEngine;
using UnityEngine.SceneManagement;

public class BACK : MonoBehaviour
{
    // �� ������ ���� ������ ��� ���� ��� ����
    public void LoadSceneByBack()
    {
        SceneManager.LoadScene(1); // �� ����� ������ ��� 0 �� Build Settings
    }
}
