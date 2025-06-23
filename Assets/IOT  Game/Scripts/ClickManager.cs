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
        /*  if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
          {
              HandleClick(Input.GetTouch(0).position);
          }*/
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Only react on TouchPhase.Began (the moment the finger touches the screen)
            if ( touch.phase == TouchPhase.Ended)

            {

                HandleClick(Input.GetTouch(0).position);
            }
        }
    }





    void HandleClick(Vector3 screenPosition)
    {
        Ray ray = Camera.main.ScreenPointToRay(screenPosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log("Touched: " + hit.collider.name);
            CapsuleClickActivator capsule = hit.collider.GetComponent<CapsuleClickActivator>();
            if (capsule != null)
            {
                Debug.Log("Touched: is 1");
                capsule.Activate();
                Debug.Log("Capsule clicked via raycast!");
            }
        }
    }
}
