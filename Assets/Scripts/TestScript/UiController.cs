using System.Collections;
using System.Collections.Generic;
using Player.Stats;
using TMPro;
using UnityEngine;

public class UiController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI waktu;
    [SerializeField] private TextMeshProUGUI uang;

    private void ChangeText()
    {
        waktu.text = GameTime.Hours.ToString();
        uang.text = PlayerStatsController.Money.ToString();
    }
    void Update()
    {
        ChangeText();
    }
}
