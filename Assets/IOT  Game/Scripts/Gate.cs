using UnityEngine;

public class Gate : MonoBehaviour
{
    private Animator animator;
    private bool isOpen = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        
    }

  public void OnHIT()
    {
         if (!isOpen)
        {
            animator.SetTrigger("OpenGate");
        }
        else
        {
            animator.SetTrigger("CloseGate");
        }

        isOpen = !isOpen;
    }
}