using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AdviceTextBehaviour : MonoBehaviour
{
    public TextMeshProUGUI TMPText;
    // Start is called before the first frame update
    public void Start()
    {
        if (TMPText is null)
        {
            TMPText = GetComponent<TextMeshProUGUI>();
        }
        TMPText.text = "Press E to interact";
        gameObject.SetActive(false);
    }

    void OnEnable()
    {
        CollectableBehaviour.onViewAdvice += delegate (string text)
        {
            if (text != "")
            {
                TMPText.text = text;
            }
            gameObject.SetActive(true);
        };
    }

    void OnDisable()
    {
        CollectableBehaviour.onViewDisable += delegate ()
        {
            gameObject.SetActive(false);
        };
    }
}
