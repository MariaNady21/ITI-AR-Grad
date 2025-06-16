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
            animator.SetTrigger("Open");
            isOpen = true;
        }
        else
        {
            animator.SetTrigger("Close"); // لو عملتي حالة إغلاق
            isOpen = false;
        }
    }
}