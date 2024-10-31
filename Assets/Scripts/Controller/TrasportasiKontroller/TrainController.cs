using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

namespace Controller.TrasportasiKontroller
{
    public class TrainController : Transportasi.TransportationController
    {
        private int startHour;
        [SerializeField] private GameController gameController;
        [SerializeField] private SceneController sceneController;
        [SerializeField] private GameObject arriveUI;
        [SerializeField] private GameObject exitDoor;
        [SerializeField] private GameObject colliderPintu;
        [SerializeField] private GameObject minigame;

        [SerializeField] private Button miniGameButton;

        [SerializeField] private GameObject backGroundSiang;
        [SerializeField] private GameObject backgroundMalem;
        
        private void Awake()
        {
            startHour = GameTime.Hours;
            GameTime.PauseState(false);
            arriveUI.SetActive(false);
            exitDoor.SetActive(false);
            colliderPintu.SetActive(true);
            miniGameButton.interactable = true;
            if (GameTime.Hours <= 15 )
            {
                backGroundSiang.SetActive(true);
                backgroundMalem.SetActive(false);
            }
            else
            {
                backgroundMalem.SetActive(true);
                backGroundSiang.SetActive(false);
            }
        }

        private void Update()
        {
            if (GetHourDuration() > GameTime.Hours) return;
            arriveUI.SetActive(true);
            exitDoor.SetActive(true);
            miniGameButton.interactable = false;
            GameTime.PauseState(true);
            minigame.SetActive(false);
            colliderPintu.SetActive(false);
            gameController.SetGameSpeed(0f);
        }
        
        public int GetHourDuration()
        {
            return startHour + transportDuration;
        }
    }
}
