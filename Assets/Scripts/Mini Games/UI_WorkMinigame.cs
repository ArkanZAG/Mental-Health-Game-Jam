using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

delegate Color DelegateColor();
public class UI_WorkMinigame : MonoBehaviour
{
    [SerializeField] private List<Color> tableColorList = new List<Color>();

    private List<string> colorList = new List<string>
    {
        "green",
        "white",
        "red",
        "yellow",
        "orange",
        "blue",

    };

    private Dictionary<string, int> colorCount = new Dictionary<string, int>
    {
        {"green", 0},
        {"white", 0 },
        {"red", 0 },
        {"yellow", 0 },
        {"orange", 0 },
        {"blue", 0 },
    };

    private int _maxColorAmount = 6;

    // Start is called before the first frame update
    void Start()
    {
        
        DelegateColor color = delegate
        {
            System.Random random = new System.Random();
            var index = random.Next(0, colorList.Count-1);
            var chosenColor = colorList[index];
            colorCount[colorList[index]] += 1;
            if (colorCount[colorList[index]] >= _maxColorAmount)
            {
                colorList.Remove(colorList[index]);
            }

            return assignColorWithString(chosenColor);
        };

        tableColorList = Enumerable
            .Range(0, 36)
            .Select(__ => color()).ToList<Color>();

        print(tableColorList.Count);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Color assignColorWithString(string color)
    {
        switch (color)
        {
            case "green":
                return Color.green;
            case "white":
                return Color.white;
            case "red":
                return Color.red;
            case "yellow":
                return Color.yellow;
            case "orange":
                return Color.magenta;
            case "blue":
                return Color.blue;
            default:
                return Color.blue;
        }
    }
}
