using UnityEngine;

public class GameControllerForGates : MonoBehaviour
{
   

  /*  public static GameControllerForGates instance;

    private int score = 0;

    void Awake()
    {
        instance = this;
    }*/

    void Update()
    {

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
        //    Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
           // HandleRaycast(ray);
            HandleClick(Input.GetTouch(0).position);
        }


        if (Input.GetMouseButtonDown(0))
        {
           // Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            // HandleRaycast(ray);
            HandleClick(Input.mousePosition);
        }
    }

    /*    void HandleRaycast(Ray ray)
        {
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Gate gate = hit.collider.GetComponent<Gate>();
                if (gate != null)
                {
                    gate.OnHIT();
                }
            }
        }*/

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



/*    public void AddScore(int amount)
    {
        score += amount;
        Debug.Log(" Score: " + score);

    }*/
}


