using System;
using Player.Stats;
using TMPro;
using UnityEngine;

namespace UI
{
    public class ReportCardUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI exhaustionText;
        [SerializeField] private TextMeshProUGUI stressText;
        [SerializeField] private TextMeshProUGUI moneyText;

        [SerializeField] private TextMeshProUGUI exhaustionDelta;
        [SerializeField] private TextMeshProUGUI stressDelta;
        [SerializeField] private TextMeshProUGUI moneyDelta;


        private void Start()
        {
            exhaustionText.text = $"{PlayerStatsController.Exhaustion.ToString()} / 100";
            stressText.text = $"{PlayerStatsController.Stress.ToString()} / 100";
            moneyText.text = PlayerStatsController.Money.ToString();

            exhaustionDelta.text = $"{PlayerStatsController.Exhaustion - PlayerStatsController.initialExhaustion}";
            stressDelta.text = $"{PlayerStatsController.Stress - PlayerStatsController.initialStress}";
            moneyDelta.text = $"{PlayerStatsController.Money - PlayerStatsController.initialMoney}";
        }
    }
}