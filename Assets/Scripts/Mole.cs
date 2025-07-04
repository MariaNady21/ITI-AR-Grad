﻿using UnityEngine;

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
            AudioManager.instance.PlaySFX("Explosion");
            GameObject vfx = Instantiate(gameManager.explosionVFX, transform.position, Quaternion.identity);
            Destroy(vfx, 2f);
            gameManager.PlayerLose(); // استدعاء خسارة
        }
        else
        {
            gameManager.IncreaseScore(myHoleIndex, transform.position);
        }

        Destroy(gameObject);
    }





}
