using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

//using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;
using UnityEngine.UIElements;

public class Scorenum : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI textscore;

    //public Scorenum script;
    public GameObject winpanel;
    public GameObject losepanel;

    public bool panelShown = false;
    AudioManager audioManager;
    /* public GameObject winpanel;
     public GameObject losepanel;
     public static int counter = 0;
     private bool panelShown = false;*/
    void Start()
    {
        audioManager = AudioManager.instance;
        
    }

    void Update()
    {
        textscore.text = score.ToString();



        if (panelShown) return; // Prevent showing again

        if (score >= 40 && Vehicle.counter == 4)
        {
            audioManager.PlaySFX("WinCar labs");
            audioManager.StopMusic();
            winpanel.SetActive(true);
            panelShown = true;
            Vehicle.counter = 0;
        }
        else if (score < 40 && Vehicle.counter == 4)
        {
           audioManager.PlaySFX("carLabs Lose");
            audioManager.StopMusic();
            losepanel.SetActive(true);
            panelShown = true;
            Vehicle.counter = 0;
        }




    }

<<<<<<< Updated upstream
    
=======
   
>>>>>>> Stashed changes
}
