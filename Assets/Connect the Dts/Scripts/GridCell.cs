using UnityEngine;

public class GridCell : MonoBehaviour
{
    public Vector2Int GridPosition;
    public Vector3 GetCenterPosition()
    {
        return transform.position;
    }
}
