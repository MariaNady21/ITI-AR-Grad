using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class IOTGame : MonoBehaviour
{
    public static IOTGame Instance;

    [Header("Line Drawing")]
    [SerializeField] private GameObject linePrefab;
    [SerializeField] private Transform lineParent;

    private LineRenderer currentLine;
    private List<Vector3> linePoints = new List<Vector3>();

    private Node startNode;
    private List<Node> visitedNodes = new List<Node>();
    private GridCell lastGridCell = null;
    private HashSet<GridCell> visitedGridCells = new HashSet<GridCell>();

    private bool isDrawing = false;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Update()
    {
        if (!isDrawing || currentLine == null)
            return;

        // Detect current grid cell under the mouse
        PointerEventData pointerData = new PointerEventData(EventSystem.current)
        {
            position = Input.mousePosition
        };

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData, results);

        foreach (var result in results)
        {
            GridCell cell = result.gameObject.GetComponent<GridCell>();
            if (cell != null && !visitedGridCells.Contains(cell))
            {
                if (lastGridCell == null || AreNeighbors(lastGridCell, cell))
                {
                    Vector3 pos = cell.GetCenterPosition();

                    linePoints.Add(pos);
                    visitedGridCells.Add(cell);
                    currentLine.positionCount = linePoints.Count;
                    currentLine.SetPositions(linePoints.ToArray());
                    lastGridCell = cell;
                }

            }
        }
    }
    private bool AreNeighbors(GridCell a, GridCell b)
    {
        int dx = Mathf.Abs(a.GridPosition.x - b.GridPosition.x);
        int dy = Mathf.Abs(a.GridPosition.y - b.GridPosition.y);

        // يسمح بالحركة لأعلى/أسفل/يمين/يسار فقط (مش مائل)
        return (dx == 1 && dy == 0) || (dx == 0 && dy == 1);
    }


    public void StartDrawing(Node node)
    {
        if (isDrawing) return;

        startNode = node;
        isDrawing = true;

        GameObject newLine = Instantiate(linePrefab, lineParent);
        currentLine = newLine.GetComponent<LineRenderer>();
        currentLine.positionCount = 2;

        Vector3 startPos = node.transform.position;
        linePoints.Clear();
        visitedNodes.Clear();
        visitedNodes.Add(node);
        linePoints.Add(startPos);
        linePoints.Add(startPos);// بداية الخط
        currentLine.SetPositions(linePoints.ToArray());
        currentLine.material = new Material(Shader.Find("Sprites/Default"));
        currentLine.startColor = node.NodeColor;
        currentLine.endColor = node.NodeColor;
        visitedGridCells.Clear();

        lastGridCell = null; // Reset last grid cel
    }

    public void TryConnectTo(Node targetNode)
    {


        if (!isDrawing || startNode == null) return;

        if (visitedNodes.Contains(targetNode)) return; // متكررش نفس النود

        if (targetNode.ColorId == startNode.ColorId)
        {
            visitedNodes.Add(targetNode);

            Vector3 newPoint = targetNode.transform.position;
            linePoints.Add(newPoint);
            currentLine.positionCount = linePoints.Count;
            currentLine.SetPositions(linePoints.ToArray());
        }

    }

    public void CancelLine()
    {
        if (currentLine != null)
        {
            Destroy(currentLine.gameObject);
        }

        isDrawing = false;
        startNode = null;
        currentLine = null;
    }
    public void EndDrawing()
    {
        isDrawing = false;
        startNode = null;
        currentLine = null;
        visitedNodes.Clear();
        lastGridCell = null;
    }
}