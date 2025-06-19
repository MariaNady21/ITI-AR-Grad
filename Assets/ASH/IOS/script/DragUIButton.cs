using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;

public class DragUIButton : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    private Vector3 offset;
    private Camera mainCamera;
    private RectTransform rectTransform;
    private Canvas canvas;

    public List<Transform> dropTargets;
    public float snapDistance = 0.5f;

    private CanvasGroup canvasGroup;
    private bool isDragging = false;

    [Header("Drag Control")]
    public bool canDrag = false; // ? „„‰Ê⁄ «·”Õ» ›Ì «·»œ«Ì…

    void Start()
    {
        mainCamera = Camera.main;
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!canDrag) return;

        isDragging = true;
        canvasGroup.blocksRaycasts = false;

        RectTransformUtility.ScreenPointToWorldPointInRectangle(rectTransform, eventData.position, mainCamera, out var worldPoint);
        offset = rectTransform.position - worldPoint;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!isDragging || !canDrag) return;

        RectTransformUtility.ScreenPointToWorldPointInRectangle(rectTransform, eventData.position, mainCamera, out var worldPoint);
        rectTransform.position = worldPoint + offset;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (!canDrag) return;

        isDragging = false;
        canvasGroup.blocksRaycasts = true;

        CheckDrop();
    }

    void CheckDrop()
    {
        Transform closestTarget = null;
        float closestDistance = Mathf.Infinity;

        foreach (Transform target in dropTargets)
        {
            float dist = Vector3.Distance(rectTransform.position, target.position);
            if (dist < closestDistance)
            {
                closestDistance = dist;
                closestTarget = target;
            }
        }

        if (closestTarget != null && closestDistance <= snapDistance)
        {
            rectTransform.position = closestTarget.position;
        }
    }
}
