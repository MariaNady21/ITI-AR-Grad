using UnityEngine;

public class DropReceiver : MonoBehaviour
{
    private float dropOffsetX = -0.05f;
    private float spacing = 0.05f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            HandleRaycast(ray);
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            HandleRaycast(ray);
        }
    }

    void HandleRaycast(Ray ray)
    {
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform == transform)
            {
                if (SelectableElement.selectedElement != null)
                {
                    GameObject selectedObj = SelectableElement.selectedElement.gameObject;

                    if (selectedObj == null)
                    {
                        Debug.LogWarning("📛 selectedObj null!");
                        return;
                    }

                    Vector3 targetPos = transform.position;
                    targetPos.y += 0.01f;
                    targetPos.x += dropOffsetX;

                    dropOffsetX += spacing;

                    SelectableElement.selectedElement.MoveTo(targetPos);

                    BoxManager boxManager = FindObjectOfType<BoxManager>();
                    if (boxManager != null)
                    {
                        boxManager.AddItem(selectedObj);
                    }
                    else
                    {
                        Debug.LogWarning("📛 BoxManager مش لاقيه!");
                    }
                }
                else
                {
                    Debug.LogWarning("📛 مفيش selectedElement متعلم!");
                }
            }
        }
    }
}
