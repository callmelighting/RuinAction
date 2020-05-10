using UnityEngine;
using UnityEngine.UI;

public class HintTextControl : MonoBehaviour
{
    private Text hintText;
    private Animator animator;

    void Start()
    {
        hintText = GetComponent<Text>();
        animator = GetComponent<Animator>();
    }

    public void ShowHintText(string text)
    {
        hintText.text = text;
        animator.SetTrigger("ShowText");
    }
}
