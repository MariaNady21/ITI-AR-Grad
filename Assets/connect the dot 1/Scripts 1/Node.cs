using UnityEngine;

public class Node : MonoBehaviour
{
    public Color nodeColor;
    public string nodeID; // unique ID to identify the pair

    private void OnDrawGizmos()
    {
        Gizmos.color = nodeColor;
        Gizmos.DrawSphere(transform.position + Vector3.up * 0.01f, 0.05f);
    }
}
