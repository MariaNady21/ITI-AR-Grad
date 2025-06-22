using UnityEngine;

public class TabManager : MonoBehaviour
{
    public GameObject[] tabs;

    public void SwitchTab(string tabName)
    {
        foreach (GameObject tab in tabs)
        {
            bool isActive = tab.tag == tabName;
            tab.SetActive(isActive);

            // ✅ تشغيل الموسيقى فقط لو التبويب هو MiniGame
            if (isActive && tab.tag == "MiniGame")
            {
                AudioManager.instance.PlayMusic("BackGround");
            }
            else if (isActive && tab.tag == "Info")
            {
                AudioManager.instance.StopMusic(); // لو عايز توقفها
            }
        }
    }
}

