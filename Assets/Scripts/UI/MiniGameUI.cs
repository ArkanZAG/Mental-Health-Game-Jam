using System;
using System.Collections.Generic;
using Controller;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class MiniGameUI : MonoBehaviour
    {
        [System.SerializableAttribute]
        struct MiniGameObjects {
            public GameObject prefab;
            public Button button;
        }
        [SerializeField] private Button miniGameButton;
        [SerializeField] private GameObject miniGameHolder;
        
        // [SerializeField] private Button workButton;
        // [SerializeField] private Button restButton;
        // [SerializeField] private Button playButton;

        // [SerializeField] private GameObject sleepPrefabs;
        // [SerializeField] private GameObject playGamePrefabs;
        // [SerializeField] private GameObject workPrefabs;
        [SerializeField] private List<MiniGameObjects> miniGameObjects;

        private GameObject activeMiniGame;

        private void Start()
        {
            foreach (var miniGame in miniGameObjects)
            {
                miniGame.prefab.SetActive(false);
                miniGame.button.onClick.AddListener(CloseUI);
                miniGame.button.onClick.AddListener(delegate {
                    DisplayActiveMiniGame(miniGame.prefab);
                    });
            }

            miniGameButton.onClick.AddListener(OnClick);
            
            //workButton.onClick.AddListener(DisplayWorkMiniGame);
            //restButton.onClick.AddListener(Resting);
            //playButton.onClick.AddListener(DisplayPlayMiniGame);
            
            //workPrefabs.SetActive(false);
            //playGamePrefabs.SetActive(false);
            //sleepPrefabs.SetActive(false);
            //miniGameHolder.SetActive(false);
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

        private void DisplayActiveMiniGame(GameObject prefab) {
            if (activeMiniGame != null) {
                activeMiniGame.SetActive(false);
            }
            activeMiniGame = prefab;
            activeMiniGame.SetActive(true);
        }

        // private void CloseMiniGame()
        // {
        //     if (activeMiniGame)
        //     {
        //         activeMiniGame.SetActive(false);
        //         activeMiniGame = null;
        //     }
        // }
        // private void DisplayWorkMiniGame()
        // {
        //     if (!sleepPrefabs.activeSelf && !playGamePrefabs.activeSelf)
        //     {
        //         workPrefabs.SetActive(true);
        //         CloseUI();
        //     }
        //     else
        //     {
        //         throw new Exception("Unable to open cause another one already opened");
        //     }
        // }
        // private void Resting()
        // {
        //     if (!workPrefabs.activeSelf && !playGamePrefabs.activeSelf)
        //     {
        //         sleepPrefabs.SetActive(true);
        //         CloseUI();
        //     }
        //     else
        //     {
        //         throw new Exception("Unable to open cause another one already opened");
        //     }
        // }

        // private void DisplayPlayMiniGame()
        // {
        //     if (!workPrefabs.activeSelf && !sleepPrefabs.activeSelf)
        //     {
        //         playGamePrefabs.SetActive(true);
        //         CloseUI();
        //     }
        //     else
        //     {
        //         throw new Exception("Unable to open cause another one already opened");
        //     }
        // }
    }
}