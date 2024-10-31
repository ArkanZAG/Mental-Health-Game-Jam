using System;
using Player.Stats;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class PlayerUI : MonoBehaviour
    {
        [SerializeField] private Slider stressSlider;

        private void Update()
        {
            stressSlider.value = PlayerStatsController.Stress;
        }
    }
}