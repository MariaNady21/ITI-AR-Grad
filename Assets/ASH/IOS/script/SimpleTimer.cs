using UnityEngine;
using TMPro;

public class SimpleTimer : MonoBehaviour
{
    public float timeRemaining = 30f;
    public TextMeshProUGUI timerText;
    private bool isRunning = false;
    private bool hasEnded = false;

    [Header("äÊíÌÉ ÇááÚÈ")]
    public GameObject winImage;      // ÕæÑÉ ÇáÝæÒ
    public GameObject loseImage;     // ÕæÑÉ ÇáÎÓÇÑÉ

    [Header("ÍÇÌÇÊ åÊÎÊÝí ÈÚÏ ÇáäåÇíÉ")]
    public GameObject[] objectsToHideOnEnd;

    [Header("ÃÕæÇÊ ÇáäÊíÌÉ")]
    public AudioClip winSound;
    public AudioClip loseSound;
    public AudioSource audioSource;

    void OnEnable()
    {
        isRunning = true;
        hasEnded = false;
    }

    void Update()
    {
        if (!isRunning || hasEnded) return;

        // ÊÍÏíË ÇáæÞÊ
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

        if (audioSource != null && winSound != null)
            audioSource.PlayOneShot(winSound);

        HideOthers();
    }

    void ShowLose()
    {
        if (loseImage != null)
            loseImage.SetActive(true);

        if (audioSource != null && loseSound != null)
            audioSource.PlayOneShot(loseSound);

        HideOthers();
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
