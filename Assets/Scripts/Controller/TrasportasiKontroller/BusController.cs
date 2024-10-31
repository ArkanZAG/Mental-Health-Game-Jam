using System;
using System.Collections.Generic;
using DefaultNamespace;
using RandomEvents;
using UnityEngine;

namespace Controller.TrasportasiKontroller
{
    public class BusController : Transportasi.TransportationController
    {
        private int startHour;
        [SerializeField] private GameController gameController;
        [SerializeField] private SceneController sceneController;
        [SerializeField] private RandomEvent randomEvent;
        [SerializeField] private GameObject arriveUI;
        [SerializeField] private GameObject exitDoor;

        [SerializeField] private List<GameObject> backGround;
        private void Awake()
        {
            startHour = GameTime.Hours;
            randomEvent.DoEvent();
            GameTime.PauseState(false);
            arriveUI.SetActive(false);
            exitDoor.SetActive(false);
        }

        private void Update()
        {
            if (GetHourDuration() >= GameTime.Hours) return;
            arriveUI.SetActive(true);
            exitDoor.SetActive(true);
            GameTime.PauseState(true);
            
        }

        public int GetHourDuration()
        {
            return startHour + transportDuration;
        }
    }
}