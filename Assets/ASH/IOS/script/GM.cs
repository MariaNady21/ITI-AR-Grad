using UnityEngine;

public class GM : MonoBehaviour
{
    public static GM Instance;

    public bool isPhonePhase = false;

    void Awake()
    {
        Instance = this;
    }
}
