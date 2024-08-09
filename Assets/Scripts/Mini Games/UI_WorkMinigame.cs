using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

delegate Color DelegateColor();
public class UI_WorkMinigame : MonoBehaviour
{
    [SerializeField] private GameObject cellParent;
    [SerializeField] private GameObject cellPrefab;
    private List<GameObject> cellImageList = new List<GameObject>(0);

    private List<Color> tableColorList = new List<Color>();
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

        SpawnRandomColorTable();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnRandomColorTable()
    {
        // Generate random color
        DelegateColor color = delegate
        {
            System.Random random = new System.Random();
            var index = random.Next(0, colorList.Count);
            var chosenColor = colorList[index];
            colorCount[colorList[index]] += 1;
            if (colorCount[colorList[index]] >= _maxColorAmount)
            {
                colorList.Remove(colorList[index]);
            }

            return AssignColorWithString(chosenColor);
        };

        tableColorList = Enumerable
            .Range(0, 36)
            .Select(__ => color()).ToList<Color>();

        // Instantiate cell with color in table parent
        for (int i = 0; i < tableColorList.Count; i++)
        {
            GameObject newCell = Instantiate(cellPrefab, cellParent.transform);
            newCell.GetComponent<Image>().color = tableColorList[i];
            cellImageList.Add(newCell);
        }
    }
    private Color AssignColorWithString(string color)
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
