using System;
using Player.Stats;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class PlayerUI : MonoBehaviour
    {
        [SerializeField] private Slider stressSlider;
        [SerializeField] private float money;

        private void Update()
        {
            stressSlider.value = PlayerStatsController.Stress;
            money = PlayerStatsController.Money;
        }
    }
}