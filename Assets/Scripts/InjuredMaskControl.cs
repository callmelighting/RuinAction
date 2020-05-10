using UnityEngine;

public class InjuredMaskControl : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Show()
    {
        animator.SetTrigger("Show");
    }
}
