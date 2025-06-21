using System.Collections.Generic;
using UnityEngine;

public class BoxManager : MonoBehaviour
{
    public int maxItems = 4;
    private int currentItems = 0;

    public GameObject[] objectsToHide;
    public GameObject buildPhasePanel;
    public Transform buildItemsParent;
    public Transform[] slots;

    private List<GameObject> collectedItems = new List<GameObject>();
    private List<Vector3> originalScales = new List<Vector3>();

    [Header("Explosion Effect")]
    public GameObject explosionEffectPrefab;
    public AudioClip explosionSound;
    public AudioSource audioSource;

    [Header("عناصر إضافية بعد البناء")]
    public GameObject extraPhoneObject;
    public GameObject extraThingObject;
    public GameObject actionButton;

    [Header("زرار إضافي بعد البناء")]
    public GameObject extraButtonObject;

    public void AddItem(GameObject item)
    {
        if (item == null)
        {
            Debug.LogWarning("📛 AddItem استقبل null – فيه مشكلة في السحب!");
            return;
        }

        currentItems++;
        item.SetActive(false);
        collectedItems.Add(item);
        originalScales.Add(item.transform.localScale);

        if (currentItems >= maxItems)
        {
            // 🎆 تأثير الانفجار
            if (explosionEffectPrefab != null)
            {
                Instantiate(explosionEffectPrefab, transform.position, Quaternion.identity);
            }

            // ✅ تشغيل صوت الانفجار من AudioManager
            if (AudioManager.instance != null)
            {
                AudioManager.instance.PlaySFX("Explosion");
            }
            else
            {
                Debug.LogWarning("❗ AudioManager مش لاقيه! الصوت مش هيتشغل");
            }

            foreach (GameObject obj in objectsToHide)
                obj.SetActive(false);

            gameObject.SetActive(false);
            buildPhasePanel.SetActive(true);
            buildItemsParent.gameObject.SetActive(true);

            GM.Instance.isPhonePhase = true;

            for (int i = 0; i < collectedItems.Count && i < slots.Length; i++)
            {
                GameObject original = collectedItems[i];
                GameObject clone = Instantiate(original);

                clone.SetActive(true);
                clone.transform.SetParent(buildItemsParent, false);
                clone.transform.position = slots[i].position;
                clone.transform.rotation = Quaternion.identity;

                switch (clone.tag)
                {
                    case "button":
                        clone.transform.localScale = new Vector3(0.3f, 0.5f, 0.2f);
                        break;
                    case "text":
                        clone.transform.localScale = new Vector3(0.2f, 0.3f, 0.2f);
                        break;
                    case "image":
                        clone.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
                        break;
                    case "input":
                        clone.transform.localScale = new Vector3(0.3f, 0.4f, 0.2f);
                        break;
                    default:
                        clone.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                        break;
                }

                FixTextDirection(clone);
            }

            if (extraPhoneObject != null)
                extraPhoneObject.SetActive(true);

            if (extraThingObject != null)
                extraThingObject.SetActive(true);

            if (actionButton != null)
                actionButton.SetActive(true);

            if (extraButtonObject != null)
                extraButtonObject.SetActive(true);
        }
    }

    void FixTextDirection(GameObject obj)
    {
        foreach (Transform child in obj.transform)
        {
            if (child.GetComponent<TextMesh>() || child.GetComponent<TMPro.TextMeshPro>())
            {
                child.localEulerAngles = Vector3.zero;

                Vector3 scale = child.localScale;
                if (scale.y < 0) scale.y *= -1;
                child.localScale = scale;
            }
        }
    }
}
