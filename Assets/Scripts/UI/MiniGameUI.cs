using System;
using Controller;
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

        [SerializeField] private Button closeWorkMiniGameButton;
        [SerializeField] private Button closeRestMiniGameButton;
        [SerializeField] private Button closePlayMiniGameButton;

        [SerializeField] private GameObject sleepPrefabs;
        [SerializeField] private GameObject playGamePrefabs;
        [SerializeField] private GameObject workPrefabs;

        private void Start()
        {
            workButton.onClick.AddListener(DisplayWorkMiniGame);
            restButton.onClick.AddListener(Resting);
            playButton.onClick.AddListener(DisplayPlayMiniGame);
            miniGameButton.onClick.AddListener(OnClick);
            closeWorkMiniGameButton.onClick.AddListener(CloseMiniGame);
            closeRestMiniGameButton.onClick.AddListener(CloseMiniGame);
            closePlayMiniGameButton.onClick.AddListener(CloseMiniGame);
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

        private void CloseMiniGame()
        {
            if (workPrefabs.activeSelf || sleepPrefabs.activeSelf || playGamePrefabs.activeSelf)
            {
                workPrefabs.SetActive(false);
                sleepPrefabs.SetActive(false);
                playGamePrefabs.SetActive(false);
            }
        }
        private void DisplayWorkMiniGame()
        {
            if (!sleepPrefabs.activeSelf && !playGamePrefabs.activeSelf)
            {
                workPrefabs.SetActive(true);
                CloseUI();
            }
            else
            {
                throw new Exception("Unable to open cause another one already opened");
            }
        }
        private void Resting()
        {
            if (!workPrefabs.activeSelf && !playGamePrefabs.activeSelf)
            {
                sleepPrefabs.SetActive(true);
                CloseUI();
            }
            else
            {
                throw new Exception("Unable to open cause another one already opened");
            }
        }

        private void DisplayPlayMiniGame()
        {
            if (!workPrefabs.activeSelf && !sleepPrefabs.activeSelf)
            {
                playGamePrefabs.SetActive(true);
                CloseUI();
            }
            else
            {
                throw new Exception("Unable to open cause another one already opened");
            }
        }
    }
}