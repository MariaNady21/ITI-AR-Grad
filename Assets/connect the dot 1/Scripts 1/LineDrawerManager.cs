using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class LineDrawerManager : MonoBehaviour
{
    [SerializeField] LayerMask nodeLayer;
    [SerializeField] LayerMask gridLayer;
    [SerializeField] GameObject winPanel;
    private Node startNode;
    private Node currentNode;

    public Color currentColor;
    public string currentID;

    private List<GameObject> visitedGridQuads = new List<GameObject>();
    private HashSet<string> completedIDs = new HashSet<string>();
    private Dictionary<GameObject, string> cellOwners = new Dictionary<GameObject, string>();

    private HashSet<string> allNodeIDs = new HashSet<string>();
    AudioManager audioManager;
    void Start()
    {
        // ✅ تشغيل صوت الخلفية عند بدء اللعبة
        if (AudioManager.instance != null)
        {
            AudioManager.instance.PlayMusic("bg emb");
        }
        else
        {
            Debug.LogWarning("❗ AudioManager مش لاقيه! الصوت الخلفي مش هيتشغل");
        }

        Node[] nodes = FindObjectsOfType<Node>();
        foreach (Node node in nodes)
        {
            allNodeIDs.Add(node.nodeID);
        }

        Debug.Log("Total node pairs to match: " + allNodeIDs.Count);
    }


    void Update()
    {

        Vector2 inputPos = Vector2.zero;
        bool down = false, held = false, up = false;

        // Mouse
        if (Input.GetMouseButtonDown(0)) { inputPos = Input.mousePosition; down = true; }
        else if (Input.GetMouseButton(0)) { inputPos = Input.mousePosition; held = true; }
        else if (Input.GetMouseButtonUp(0)) { inputPos = Input.mousePosition; up = true; }

        // Touch
        if (Input.touchCount > 0)
        {
            Touch t = Input.GetTouch(0);
            inputPos = t.position;
            down = t.phase == TouchPhase.Began;
            held = t.phase == TouchPhase.Moved || t.phase == TouchPhase.Stationary;
            up = t.phase == TouchPhase.Ended;
        }

        if (down) HandleStart(inputPos);
        if (held) HandleDrag(inputPos);
        if (up) HandleEnd();
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 200f))
            {
                Debug.Log("Hit: " + hit.collider.name);
            }
            else
            {
                Debug.Log("Raycast missed");
            }
        }
    }

    void HandleStart(Vector2 screenPos)
    {
        Ray ray = Camera.main.ScreenPointToRay(screenPos);
        if (Physics.Raycast(ray, out RaycastHit hit, 200f, nodeLayer))
        {
            Node node = hit.collider.GetComponent<Node>();
            if (completedIDs.Contains(node.nodeID))
            {
                Debug.Log("Connection already completed for: " + node.nodeID);
                return;
            }
            startNode = node;
            currentNode = startNode;

            currentColor = startNode.nodeColor;
            currentColor.a = 1f;
            currentID = startNode.nodeID;

            visitedGridQuads.Clear();
            Debug.Log("Started from node: " + currentNode.name + ", Color: " + currentColor);
        }
    }

    void HandleDrag(Vector2 screenPos)
    {
        if (startNode == null) return;

        Ray ray = Camera.main.ScreenPointToRay(screenPos);
        if (Physics.Raycast(ray, out RaycastHit hit, 200f, gridLayer))
        {
            GameObject quad = hit.collider.gameObject;

            Debug.Log("Grid Hit: " + quad.name);
            if (!visitedGridQuads.Contains(quad))
            {
                visitedGridQuads.Add(quad);
                Debug.Log("Coloring quad: " + quad.name + " with color: " + currentColor);
                ApplyColorToQuad(quad, currentColor);
            }
        }


        if (Physics.Raycast(ray, out RaycastHit nodeHit, 200f, nodeLayer))
        {
            Node hitNode = nodeHit.collider.GetComponent<Node>();

            if (hitNode != currentNode && hitNode.nodeID == currentID)
            {

                currentNode = hitNode;
                Debug.Log("Connection Complete!");
                if (AudioManager.instance != null)
                {
                    AudioManager.instance.PlaySFX("connecteddotsound");
                }
               
               if (!completedIDs.Contains(currentID))
                {
                    completedIDs.Add(currentID);
                    Debug.Log("Connection permanently locked for: " + currentID);
                    CheckWinCondition();
                }
            }

        }
        //Debug.Log("Dragging, using color: " + currentColor);

    }
    void ResetQuadColor(GameObject quad)
    {
        Renderer rend = quad.GetComponent<Renderer>();
        if (rend == null) return;

        if (rend.material == rend.sharedMaterial)
        {
            rend.material = new Material(rend.sharedMaterial);
        }


        rend.material.color = new Color(0.6300106f, 0.8868788f, 0.9622641f);
    }
    void HandleEnd()
    {
        bool connectionFailed = (currentNode == null || currentNode == startNode);

        if (connectionFailed)
        {
            //Debug.Log("Connection failed. Resetting colored cells.");
            foreach (GameObject quad in visitedGridQuads)
            {
                ResetQuadColor(quad);
            }
        }

        visitedGridQuads.Clear();
        startNode = null;
        currentNode = null;
    }
    void ClearPathByID(string nodeID)
    {
        List<GameObject> toClear = new List<GameObject>();

        foreach (var kvp in cellOwners)
        {
            if (kvp.Value == nodeID)
            {
                ResetQuadColor(kvp.Key);
                toClear.Add(kvp.Key);
            }
        }

        foreach (GameObject quad in toClear)
        {
            cellOwners.Remove(quad);
        }

        completedIDs.Remove(nodeID);
    }
    void ApplyColorToQuad(GameObject quad, Color color)
    {

        Renderer rend = quad.GetComponent<Renderer>();
        if (rend == null)
        {
            //Debug.LogWarning("No Renderer on quad: " + quad.name);
            return;
        }
        if (cellOwners.ContainsKey(quad) && cellOwners[quad] != currentID)
        {
            string overwrittenID = cellOwners[quad];
            Debug.Log("Overwriting cell from " + overwrittenID + " to " + currentID);

            // Remove the previous path's lock
            completedIDs.Remove(overwrittenID);

            // Remove previous path ownership
            // Optional: Find all cells owned by overwrittenID and clear them
            ClearPathByID(overwrittenID);
        }
        if (rend.material == rend.sharedMaterial)
            rend.material = new Material(rend.sharedMaterial);

        color.a = 1f;
        rend.material.color = color;

        // Track new ownership
        cellOwners[quad] = currentID;

        Debug.Log("Applied color " + color + " to " + quad.name);

        //Debug.Log("Applied color " + color + " to " + quad.name);
    }
    void CheckWinCondition()
    {
        if (completedIDs.Count == allNodeIDs.Count)
        {
            Debug.Log("🎉 YOU WIN! All node pairs connected.");
            if (AudioManager.instance != null)
            {
                AudioManager.instance.PlaySFX("ConectTheDotWin");
                if (AudioManager.instance != null)
                {
                    AudioManager.instance.StopMusic();
                }
                else
                {
                    Debug.LogWarning("❗ AudioManager مش موجود – مش هنقدر نوقف الموسيقى");
                }

            }
            if (winPanel != null)
                winPanel.SetActive(true);
        }
    }
    public void ReloScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);


    }
   
 

}