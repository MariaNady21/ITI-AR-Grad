using UnityEngine;

public class SelectableElement : MonoBehaviour
{
    public static SelectableElement selectedElement;

    private Vector3 originalScale;
    private bool isSelected = false;

    [Header("Drag Handler Reference")]
    public DragUIButton dragHandler; // 👈 اربطيها من Inspector

    void Start()
    {
        originalScale = transform.localScale;
    }

    void Update()
    {
        if (GM.Instance != null && GM.Instance.isPhonePhase)
            return;

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
                if (selectedElement != null && selectedElement != this)
                    selectedElement.Deselect();

                selectedElement = this;
                isSelected = true;
                transform.localScale = originalScale * 1.6f;
            }
        }
    }

    public void Deselect()
    {
        isSelected = false;
        transform.localScale = originalScale;
    }

    public void MoveTo(Vector3 targetPos)
    {
        transform.position = targetPos;
        transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
        isSelected = false;
        selectedElement = null;

        if (dragHandler != null)
            dragHandler.canDrag = true; // ✅ نفعل السحب بعد الإدخال
    }
}
