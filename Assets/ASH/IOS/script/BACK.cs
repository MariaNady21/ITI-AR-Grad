using UnityEngine;
using UnityEngine.SceneManagement;

public class BACK : MonoBehaviour
{
    // �� ������ ���� ������ ��� ���� ��� ����
    public void LoadSceneByBack()
    {
        SceneManager.LoadScene(5); // �� ����� ������ ��� 0 �� Build Settings
    }
}
