
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISelectionHandler : MonoBehaviour
{
    [Header("Panel to Hide (with CanvasGroup)")]
    public GameObject panelToFadeOut;

    [Header("Audio")]
    public AudioSource selectionAudio;

    [Header("Objects to Show")]
    public List<GameObject> objectsToShow;

    [Header("Fade Settings")]
    public float fadeDuration = 5f;

    [Header("Optional: زرار مربوط على نفس الصورة")]
    public Button myButton;

    // 🟡 نحفظ الحجم والمكان
    private Dictionary<GameObject, Vector3> originalScales = new Dictionary<GameObject, Vector3>();
    private Dictionary<GameObject, Vector3> originalPositions = new Dictionary<GameObject, Vector3>();

    void Start()
    {
        foreach (GameObject go in objectsToShow)
        {
            if (go != null)
            {
                // نحفظ المكان والحجم قبل ما نخفي العنصر
                originalScales[go] = go.transform.localScale;
                originalPositions[go] = go.transform.localPosition;

                go.SetActive(false); // نخفيه
            }
        }
    }

    public void HandleClick()
    {
        if (selectionAudio != null)
            selectionAudio.Play();

        PlayerPrefs.SetString("SelectedImage", gameObject.name);

        StartCoroutine(HandleTransition());
    }

    IEnumerator HandleTransition()
    {
        // Fade out panel
        CanvasGroup cg = panelToFadeOut.GetComponent<CanvasGroup>();
        if (cg == null)
        {
            Debug.LogError("CanvasGroup missing on panel!");
            yield break;
        }

        cg.interactable = false;
        cg.blocksRaycasts = false;

        float elapsed = 0f;
        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            cg.alpha = Mathf.Lerp(1f, 0f, elapsed / fadeDuration);
            yield return null;
        }

        cg.alpha = 0f;
        panelToFadeOut.SetActive(false);

        // Show target objects with original position and scale
        foreach (GameObject go in objectsToShow)
        {
            if (go != null)
            {
                go.SetActive(true);

                // نرجّع الحجم والمكان الأصلي
                if (originalScales.ContainsKey(go))
                    go.transform.localScale = originalScales[go];

                if (originalPositions.ContainsKey(go))
                    go.transform.localPosition = originalPositions[go];

                Debug.Log("بنفعل: " + go.name);
            }
        }

        // Invoke button if exists
        if (myButton != null)
        {
            Debug.Log("بننفذ الزرار اللي جوه الصورة");
            myButton.onClick.Invoke();
        }
    }
}

