using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class MiniGameUI : MonoBehaviour
    {
        [SerializeField] private Button miniGameButton;
        [SerializeField] private GameObject miniGameHolder;
        [SerializeField] private Button workButton;
        [SerializeField] private Button restButton;
        [SerializeField] private Button playButton;

        [SerializeField] private GameObject sleepPrefabs;
        [SerializeField] private GameObject playGamePrefabs;
        [SerializeField] private GameObject workPrefabs;

        private void Start()
        {
            workButton.onClick.AddListener(DisplayWorkMiniGame);
            restButton.onClick.AddListener(Resting);
            playButton.onClick.AddListener(DisplayPlayMiniGame);
            miniGameButton.onClick.AddListener(OnClick);
            workPrefabs.SetActive(false);
            playGamePrefabs.SetActive(false);
            sleepPrefabs.SetActive(false);
            miniGameHolder.SetActive(false);
        }
        private void OnClick()
        {
            if (miniGameHolder.activeSelf)
            {
                CloseUI();
            }
            else
            {
                Display();
            }
        }
        public void Display()
        {
            miniGameHolder.SetActive(true);
        }
        private void CloseUI()
        {
            miniGameHolder.SetActive(false);
        }
        private void DisplayWorkMiniGame()
        {
            workPrefabs.SetActive(true);
        }

        private void Resting()
        {
            sleepPrefabs.SetActive(true);
        }

        private void DisplayPlayMiniGame()
        {
            playGamePrefabs.SetActive(true);
        }
    }
}