using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Node : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerUpHandler
{
    [SerializeField] private int colorId;
    [SerializeField] private Color color;

    public int ColorId => colorId;
    public Color NodeColor => color;

    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
        image.color = new Color(color.r, color.g, color.b, 1f);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        GameManager.Instance.StartDrawing(this);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        GameManager.Instance.TryConnectTo(this);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        GameManager.Instance.EndDrawing();
    }
}
