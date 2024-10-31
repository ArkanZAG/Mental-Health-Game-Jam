using System;
using Player.Stats;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace UI
{
    public class MoneyUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI moneyText;

        private void Update()
        {
            moneyText.text = "$ " + $"{PlayerStatsController.Money.ToString()}";
        }
    }
}