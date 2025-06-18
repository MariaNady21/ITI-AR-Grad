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
        Debug.Log("Clicked on: " + gameObject.name);
        if (!isOpen)
        {
            animator.SetTrigger("Open");
            isOpen = true;
        }
        else
        {
            animator.SetTrigger("Close"); 
            isOpen = false;
        }
    }
}