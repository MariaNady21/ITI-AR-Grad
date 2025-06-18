using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class CapsuleClickActivator : MonoBehaviour
{
  
    private bool isActivated = false;
   // private Animator animator;



    void Start()
    {
      //  animator = GetComponent<Animator>();
    }

    public void Activate()
    {
        Debug.Log("Capsule activated!");
        isActivated = !isActivated;
     
            if (isActivated)
            {
            transform.localEulerAngles = new Vector3(-90f, 0f, 0f); // Set directly

            Debug.Log("hi1");
            }
            else
            {
            transform.localEulerAngles = Vector3.zero;

            Debug.Log("hi2");
            }
    }

    public bool IsActivated()
    {
        return isActivated;
    }
}
