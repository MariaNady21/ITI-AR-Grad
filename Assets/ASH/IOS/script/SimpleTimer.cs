using UnityEngine;
using TMPro;

public class SimpleTimer : MonoBehaviour
{
    public float timeRemaining = 30f;
    public TextMeshProUGUI timerText;
    private bool isRunning = false;
    private bool hasEnded = false;

    [Header("نتيجة اللعب")]
    public GameObject winImage;
    public GameObject loseImage;

    [Header("حاجات هتختفي بعد النهاية")]
    public GameObject[] objectsToHideOnEnd;

    [Header("Audio Source خاص بصوت الخلفية")]
    public AudioSource bgiossAudioSource; // ← اسحبي عليه AudioSource بتاع bgioss من Inspector

    void OnEnable()
    {
        isRunning = true;
        hasEnded = false;
    }

    void Update()
    {
        if (!isRunning || hasEnded) return;

        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            timerText.text = Mathf.Ceil(timeRemaining).ToString("00");
        }
        else if (!hasEnded)
        {
            isRunning = false;
            hasEnded = true;
            ShowLose();
        }
    }

    public void StartTimer()
    {
        timeRemaining = 30f;
        isRunning = true;
        hasEnded = false;
    }

    public void PlayerClickedButton()
    {
        if (!hasEnded)
        {
            isRunning = false;
            hasEnded = true;
            ShowWin();
        }
    }

    void ShowWin()
    {
        if (winImage != null)
            winImage.SetActive(true);

        if (AudioManager.instance != null)
            AudioManager.instance.PlaySFX("I won");

        StopBGIOSSound();
        HideOthers();
    }

    void ShowLose()
    {
        if (loseImage != null)
            loseImage.SetActive(true);

        if (AudioManager.instance != null)
            AudioManager.instance.PlaySFX("game-over");

        StopBGIOSSound();
        HideOthers();
    }

    void StopBGIOSSound()
    {
        if (bgiossAudioSource != null && bgiossAudioSource.isPlaying)
        {
            bgiossAudioSource.Stop();
            Debug.Log("🎵 bgioss stopped");
        }
        else
        {
            Debug.LogWarning("🔇 bgiossAudioSource مش متوصل أو مش شغال");
        }
    }

    void HideOthers()
    {
        foreach (GameObject obj in objectsToHideOnEnd)
        {
            if (obj != null)
                obj.SetActive(false);
        }
    }
}
