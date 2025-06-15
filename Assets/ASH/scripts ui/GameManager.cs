using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject panelWin;
    public GameObject panelLose;

    public static object Instance { get; internal set; }

    public void ShowLosePanel()
    {
        panelWin.SetActive(false);
        panelLose.SetActive(true);
    }

    public void ShowWinPanel()
    {
        panelLose.SetActive(false);
        panelWin.SetActive(true);
    }

    public static implicit operator GameManager(GM v)
    {
        throw new NotImplementedException();
    }
}
