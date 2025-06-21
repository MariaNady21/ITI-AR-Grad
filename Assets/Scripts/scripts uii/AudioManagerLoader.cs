using UnityEngine;

public class AudioManagerLoader : MonoBehaviour
{
    void Awake()
    {
        if (AudioManager.instance == null)
        {
            GameObject prefab = Resources.Load<GameObject>("Sound Manger");
            if (prefab != null)
            {
                Instantiate(prefab);
            }
        }
    }
}
