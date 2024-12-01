using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GizaDoorBehaviour : MonoBehaviour
{
    [TextArea(3, 10)]
    [SerializeField] private string text = "Error - No text was added to this object";
    [SerializeField] private PlayerController player;
    private string adviceText = "Press E to interact";
    public UnityEvent<string> onCollect;
    public UnityEvent onVictory;

    public bool isAdviceVisible;

    public static event Action<string> onViewAdvice;
    public static event Action onViewDisable;

    void Update()
    {
        if (isAdviceVisible && Input.GetKeyDown(KeyCode.E))
        {
            DisableAdvice();
            if (player.hasKey)
            {
                onVictory?.Invoke();
                isAdviceVisible = false;
                return;
            }
            onCollect?.Invoke(text);
            isAdviceVisible = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var isPlayer = collision.gameObject.GetComponent<PlayerController>();
        if (isPlayer)
        {
            EnableAdvice(adviceText);
            isAdviceVisible = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            DisableAdvice();
            isAdviceVisible = false;
        }
    }
    public static void DisableAdvice()
    {
        onViewDisable?.Invoke();
    }

    public static void EnableAdvice(string adText)
    {
        onViewAdvice?.Invoke(adText);
    }

    public void MakeVisible()
    {
        gameObject.SetActive(true);
    }
}
