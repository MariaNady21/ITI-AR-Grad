using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Mole : MonoBehaviour
{
    private GameManger gameManager;
    private int myHoleIndex;
    [SerializeField]  bool isBomb = false;

    public void Init(GameManger manager, int holeIndex)
    {
        gameManager = manager;
        myHoleIndex = holeIndex;
        ShowMole();
    }

    public void ShowMole()
    {
     
        Invoke(nameof(HideMole), 1.5f); // يختفي بعد 1.5 ثانية
    }

    void HideMole()
    {
        Destroy(gameObject);
    }

    public void Kill()
    {
        CancelInvoke();

        if (isBomb)
        {
            gameManager.PlayerLose(); // استدعاء خسارة
        }
        else
        {
            gameManager.IncreaseScore(myHoleIndex, transform.position);
        }

        Destroy(gameObject);
    }





}
