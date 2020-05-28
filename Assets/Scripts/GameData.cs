using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameData : MonoBehaviour
{
    [SerializeField] string[] firstNames = { "John", "Puck", "Maria", "Christopher", "Theon" };
    [SerializeField] string[] lastNames = { "Weaver", "Smith", "Partridge", "Troan", "Blackheart" };
    [SerializeField] string namesPath = "Assets/Text/People Names";

    Dictionary<string, string> gameText = new Dictionary<string, string>();

    int year = 1;
    int seasonIndex = 0;
    static readonly string[] SEASONS = { "Spring", "Summer", "Fall", "Winter" };
    static readonly Color32[] backgroundColors = {
        new Color32(77, 130, 23, 255),
        new Color32(47, 82, 12, 255),
        new Color32(76, 82, 11, 255),
        new Color32(99, 138, 136, 255),

    };

    int numVillagers= 3;

    public int Year { get => year; set => year = value; }
    public int NumVillagers { get => numVillagers; set => numVillagers = value; }

    public int SeasonIndex
    {
        get => seasonIndex;
        set
        {
            seasonIndex = value;
            if(seasonIndex > 3)
            {
                seasonIndex = 0;
                year++;
            }
        }
    }
    public string Seasons
    {
        get
        {
            return SEASONS[seasonIndex];
        }
    }

    public string GenerateName()
    {
        //Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(namesPath);

        var data = reader.ReadToEnd();
        var lines = data.Split('\n');

        for (int i = 0; i < lines.Length; i++)
        {
            if (lines[i].StartsWith("["))
            {
                gameText.Add(lines[i].Replace("[", String.Empty).Replace("]", String.Empty).Trim(), lines[i + 1].Trim());
            }
        }

        reader.Close();

        var firstNames = gameText["MaleFirst"].Split(',');
        var lastNames = gameText["Last"].Split(',');

        return String.Format("{0} {1}",
            firstNames[UnityEngine.Random.Range(0, firstNames.Length)].Trim(),
            lastNames[UnityEngine.Random.Range(0, lastNames.Length)].Trim()
            );
    }


    internal Color GetColor()
    {
        return backgroundColors[seasonIndex];
    }
}
