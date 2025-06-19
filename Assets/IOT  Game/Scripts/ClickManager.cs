using UnityEngine;

public class ClickManager : MonoBehaviour
{
    void Update()
    {
        // Mouse click (for editor/PC)
        if (Input.GetMouseButtonDown(0))
        {
            HandleClick(Input.mousePosition);
        }

        // Touch input (for mobile)
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            HandleClick(Input.GetTouch(0).position);
        }
    }

    void HandleClick(Vector3 screenPosition)
    {
        Ray ray = Camera.main.ScreenPointToRay(screenPosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            CapsuleClickActivator capsule = hit.collider.GetComponent<CapsuleClickActivator>();
            if (capsule != null)
            {
                capsule.Activate();
                Debug.Log("Capsule clicked via raycast!");
            }
        }
    }
}
