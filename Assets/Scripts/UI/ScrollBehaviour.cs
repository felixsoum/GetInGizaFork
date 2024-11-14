using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBehaviour : MonoBehaviour
{
    [SerializeField] private ScrollTextBehaviour mainText;

    [SerializeField] private Animator animator;
    [SerializeField] private bool animationDisplaysText = true;

    void Start()
    {
        if(mainText is null)
        {
            mainText = GetComponentInChildren<ScrollTextBehaviour>();
        }
        if(animator is null)
        {
            animator = gameObject.GetComponent<Animator>();
        }
        Debug.Log(animator);

    }
    void Update()
    {
        // Check if the user clicked the screen
        if (Input.GetMouseButtonDown(0)) // 0 is the left mouse button or tap on mobile
        {
            Debug.Log("Should run animation");
            SetTextAndOpenScroll("Example Text");
        }
    }

    public void SetTextAndOpenScroll(string text)
    {
        mainText.SetText(text);
        animator.enabled = true;
        animator.ResetTrigger("ScrollOpen");
        animator.SetTrigger("ScrollOpen");
        if (!animationDisplaysText)
        {
            mainText.gameObject.SetActive(true);
        }
    }
}
