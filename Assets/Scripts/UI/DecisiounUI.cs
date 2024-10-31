using System;
using Controller;
using Player.Stats;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class DecisiounUI : MonoBehaviour
    {
        [SerializeField] private Button yesButton;
        [SerializeField] private Button noButton;
        [SerializeField] private SceneController sceneController;

        private void Start()
        {
            yesButton.onClick.AddListener(VictoryScene);
            noButton.onClick.AddListener(GameOverScene);
        }

        private void VictoryScene()
        {
            if (PlayerStatsController.Money >= 1500)
            {
                sceneController.ChangeScene("Victory");
            }
            else
            {
                yesButton.interactable = false;
            }
        }

        private void GameOverScene()
        {
            sceneController.ChangeScene("GameOver");
        }
    }
}