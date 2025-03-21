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
        //TMPText.text = "Press E to interact";
        gameObject.SetActive(false);
    }

    public void ViewAdvice(string key)
    {
        if (key != "")
        {
            TMPText.text = Localization.GetString(key);
        }
        gameObject.SetActive(true);
    }

    public void DisableAdvice()
    {
        gameObject.SetActive(false);
    } 
}
