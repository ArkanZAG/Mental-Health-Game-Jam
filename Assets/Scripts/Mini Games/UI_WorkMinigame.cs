using Player.Stats;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

delegate Color DelegateColor();
public class UI_WorkMinigame : MonoBehaviour
{
    [SerializeField] private GameObject _cellParent;
    [SerializeField] private GameObject _cellHeadParent;
    [SerializeField] private GameObject _cellPrefab;
    private List<GameObject> _cellList = new List<GameObject>(0);
    private List<GameObject> _cellHeadList = new List<GameObject>(0);

    private GameObject _activeCell = null;
    private GameObject _chosenFirstCell = null;
    private GameObject _chosenLastCell = null;

    private int _activeCellIndex = 0;

    private List<Color> _tableColorList = new List<Color>();
    private List<int> _colorNumberList = new List<int> { 1, 2, 3, 4, 5, 6 };
    private Dictionary<int, int> _colorNumberCount = new Dictionary<int, int>
    {
        {1, 0},
        {2, 0 },
        {3, 0 },
        {4, 0 },
        {5, 0 },
        {6, 0 },
    };

    private int _maxColorAmount = 6;

    // Start is called before the first frame update
    void Start()
    {
        SpawnColorTableHead();
        SpawnRandomColorTable();
        _activeCell = _cellList[0];
        _activeCell.GetComponent<Outline>().enabled = true;
        CompletionHandler();
    }

    // Update is called once per frame
    void Update()
    {
        ArrowKeyInputHandler();
        EnterKeyInputHandler();
    }

    private void ArrowKeyInputHandler()
    {
        if (_activeCell != null && Input.anyKey)
        {
            if (_activeCell != _chosenFirstCell)
            {
                _activeCell.GetComponent<Outline>().enabled = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {

            if (_activeCellIndex >= 6)
            {
                _activeCellIndex -= 6;
            }
        } else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (_activeCellIndex < 30)
            {
                _activeCellIndex += 6;
            }
        } else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (_activeCellIndex > 0)
            {
                _activeCellIndex -= 1;
            }
        } else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(_activeCellIndex < 35)
            {
                _activeCellIndex += 1;
            }
        }

        _activeCell = _cellList[_activeCellIndex];
        _activeCell.GetComponent<Outline>().enabled = true;
    }

    private void EnterKeyInputHandler()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (_activeCell && !_chosenFirstCell)
            {
                _chosenFirstCell = _cellList[_activeCellIndex];
                _chosenFirstCell.GetComponent<Outline>().effectColor = Color.red;
            } else if (_activeCell && _chosenFirstCell && !_chosenLastCell)
            {
                _chosenLastCell = _cellList[_activeCellIndex];
                var tempColor = _chosenLastCell.GetComponent<Image>().color;

                // swap color
                _chosenLastCell.GetComponent<Image>().color = _chosenFirstCell.GetComponent<Image>().color;
                _chosenFirstCell.GetComponent<Image>().color = tempColor;

                _chosenFirstCell.GetComponent<Outline>().effectColor = Color.yellow;
                _chosenFirstCell.GetComponent <Outline>().enabled = false;

                // nullify chosen cell
                _chosenFirstCell = null;
                _chosenLastCell = null;
            }

            CompletionHandler();
        }
    }

    private void CompletionHandler()
    {
        for (int i = 0; i < _cellHeadList.Count; i++)
        {
            for (int j = i; j < i+30; j+=6 )
            {
                if (_cellHeadList[i].GetComponent<Image>().color != _cellList[j].GetComponent<Image>().color)
                {
                    return;
                }
            }
        }
        PlayerStatsController.IncrementWorkMinigameAmount();
        Debug.Log(PlayerStatsController.GetWorkMinigameAmount());
        ShuffleRandomColorTable();
    }

    private void SpawnColorTableHead()
    {
        for (int i = 0; i < _maxColorAmount; i++)
        {
            GameObject newCell = Instantiate(_cellPrefab, _cellHeadParent.transform);
            newCell.GetComponent<Image>().color = AssignColorFromInt(i+1);
            _cellHeadList.Add(newCell);
        }
    }

    private void SpawnRandomColorTable()
    {
        // Delegat function for generating random color
        DelegateColor color = delegate
        {
            System.Random random = new System.Random();
            var index = random.Next(0, _colorNumberList.Count);
            var chosenColor = _colorNumberList[index];
            _colorNumberCount[_colorNumberList[index]] += 1;
            if (_colorNumberCount[_colorNumberList[index]] >= _maxColorAmount)
            {
                _colorNumberList.Remove(_colorNumberList[index]);
            }

            return AssignColorFromInt(chosenColor);
        };

        // Enumerate random color list
        _tableColorList = Enumerable
            .Range(0, 36)
            .Select(__ => color()).ToList<Color>();

        // Instantiate cell with color in table parent
        for (int i = 0; i < _tableColorList.Count; i++)
        {
            GameObject newCell = Instantiate(_cellPrefab, _cellParent.transform);
            newCell.GetComponent<Image>().color = _tableColorList[i];
            _cellList.Add(newCell);
        }
    }

    private void ShuffleRandomColorTable()
    {
        // Shuffle color in color list with Fisher-Yates algorithm
        var random = new System.Random();
        for (int i = 0; i < _tableColorList.Count-1; i++)
        {
            var randomIdx = random.Next(i + 1, _tableColorList.Count-1);

            // swap color with random index
            var tempVal = _tableColorList[i];
            _tableColorList[i] = _tableColorList[randomIdx];
            _tableColorList[randomIdx] = tempVal;

            // Assign randomized color to cell list
            _cellList[i].GetComponent<Image>().color = _tableColorList[i];
            Debug.Log("Swap-" + i);
        }
    }
    private Color AssignColorFromInt(int color)
    {
        switch (color)
        {
            case 1:
                return new Color32(0xea, 0x77, 0x77, 0xff); // EA7777
            case 2:
                return new Color32(0xa9, 0xed, 0x80, 0xff); // A9ED8A
            case 3:
                return new Color32(0xa7, 0x6c, 0x98, 0xff); // A76C98
            case 4:
                return new Color32(0x8c, 0xcb, 0xcf, 0xff); // 8CCBCF
            case 5:
                return new Color32(0xc2, 0x87, 0x52, 0xff); // C28752
            case 6:
                return Color.white;
            default:
                return Color.gray;
        }
    }
}
