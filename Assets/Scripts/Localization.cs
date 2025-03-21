using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Localization : MonoBehaviour
{
    static Dictionary<string, string> englishDictionary = new();
    static Dictionary<string, string> frenchDictionary = new();

    static bool isEnglish = true;

    private void Awake()
    {
        string file = Path.Combine(Application.streamingAssetsPath, "Giza - Sheet1.tsv");
        string[] rows = File.ReadAllLines(file);
        for (int i = 1; i < rows.Length; i++)
        {
            string[] columns = rows[i].Split('\t');
            string key = columns[0];
            englishDictionary[key] = columns[2];
            frenchDictionary[key] = columns[3];
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            isEnglish = !isEnglish;
        }
    }

    internal static string GetString(string key)
        => isEnglish ? englishDictionary[key] : frenchDictionary[key];
}
