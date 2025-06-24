using UnityEngine;
using UnityEngine.SceneManagement;
using Vuforia;

public class ARPortalManager : MonoBehaviour
{
    [Header("Portal Settings")]
    public GameObject portalPrefab;                  // الباب (Prefab)
    public PlaneFinderBehaviour planeFinder;         // العنصر اللي بيدور على الأرض

    [Header("Audio Settings")]
    public AudioSource backgroundMusic;   // موسيقى الخلفية

    private GameObject placedPortal;
    private bool portalPlaced = false;

    void Start()
    {
        // أول ما المستخدم يضغط على الأرض، استدعي الدالة اللي بتحط البوابة
        planeFinder.OnInteractiveHitTest.AddListener(PlacePortal);

        // شغّل الموسيقى من البداية لو فيه AudioSource
        if (backgroundMusic != null)
        {
            backgroundMusic.Play();
        }
    }

    void PlacePortal(HitTestResult result)
    {
        if (!portalPlaced)
        {
            // حطي البوابة في المكان اللي المستخدم ضغط عليه
            placedPortal = Instantiate(portalPrefab, result.Position, result.Rotation);
            portalPlaced = true;
        }
    }


    // زر Reset بيرجع إمكانية تحط بوابة تاني
    public void ResetPortal()
    {
        if (placedPortal != null)
        {
            Destroy(placedPortal);
            portalPlaced = false;
        }
    }

    // 🔇 دالة لتشغيل/إيقاف الموسيقى
    public void ToggleMusic()
    {
        if (backgroundMusic == null) return;

        if (backgroundMusic.isPlaying)
        {
            backgroundMusic.Pause();
        }
        else
        {
            backgroundMusic.Play();
        }
    }
}
