using UnityEngine;

public class AudioManagerBootstrap : MonoBehaviour
{
    [SerializeField] GameObject audioManagerPrefab;

    void Awake()
    {
        if (AudioManager.instance == null)
        {
            Instantiate(audioManagerPrefab);
        }
    }
}