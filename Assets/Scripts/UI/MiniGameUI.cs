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

        private void Start()
        {
            workButton.onClick.AddListener(DisplayWorkMiniGame);
            restButton.onClick.AddListener(Resting);
            playButton.onClick.AddListener(DisplayPlayMiniGame);
            miniGameButton.onClick.AddListener(OnClick);
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
            
        }

        private void Resting()
        {
            
        }

        private void DisplayPlayMiniGame()
        {
            
        }
    }
}