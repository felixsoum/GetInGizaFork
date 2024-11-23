using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class CollectableBehaviour : MonoBehaviour
{
    [SerializeField] private bool disableOnCollect;
    [TextArea(3, 10)]
    [SerializeField] private string text = "Error - No text was added to this object";
    [SerializeField] private string adviceText = "";
    public UnityEvent<string> onCollect;

    public bool isAdviceVisible;

    public static event Action<string> onViewAdvice;
    public static event Action onViewDisable;

    void Update()
    {
        if(isAdviceVisible && Input.GetKeyDown(KeyCode.E))
        {
            DisableAdvice();
            onCollect?.Invoke(text);
            if (disableOnCollect) gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            EnableAdvice();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            DisableAdvice();
        }
    }

    private void DisableAdvice()
    {
        onViewDisable?.Invoke();
        isAdviceVisible = false;
    }

    private void EnableAdvice()
    {
        onViewAdvice?.Invoke(adviceText);
        isAdviceVisible = true;
    }
}

