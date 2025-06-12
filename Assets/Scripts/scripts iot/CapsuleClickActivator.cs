using UnityEngine;

public class CapsuleClickActivator : MonoBehaviour
{
    public Material inactiveMaterial;  // Red
    public Material activeMaterial;    // Blue

    private Renderer rend;
    private bool isActivated = false;

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.material = inactiveMaterial;
    }

    public void Activate()
    {
        isActivated = !isActivated;

        if (isActivated)
        {
            rend.material = activeMaterial;
            Debug.Log("Capsule activated!");
        }
        else
        {
            rend.material = inactiveMaterial;
            Debug.Log("Capsule deactivated!");
        }
    }

    public bool IsActivated()
    {
        return isActivated;
    }
}
