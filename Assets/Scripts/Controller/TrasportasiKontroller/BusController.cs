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
        [SerializeField] private GameObject colliderPintu;

        [SerializeField] private GameObject backgroundSiang;
        [SerializeField] private GameObject backgroundMalam;
        private void Awake()
        {
            startHour = GameTime.Hours;
            randomEvent.DoEvent();
            GameTime.PauseState(false);
            arriveUI.SetActive(false);
            exitDoor.SetActive(false);
            exitDoor.SetActive(false);
            colliderPintu.SetActive(true);
            if (GameTime.Hours <= 15)
            {
                backgroundSiang.SetActive(true);
                backgroundMalam.SetActive(false);
            }
            else
            {
                backgroundSiang.SetActive(false);
                backgroundMalam.SetActive(true);
            }
        }

        private void Update()
        {
            if (GetHourDuration() >= GameTime.Hours) return;
            arriveUI.SetActive(true);
            colliderPintu.SetActive(false);
            exitDoor.SetActive(true);
            GameTime.PauseState(true);
            
        }

        public int GetHourDuration()
        {
            return startHour + transportDuration;
        }
    }
}