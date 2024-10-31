using System;
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

        [SerializeField] private GameObject exitDoor;
        private void Awake()
        {
            startHour = GameTime.Hours;
            randomEvent.DoEvent();
            GameTime.PauseState(false);
            exitDoor.SetActive(false);
        }

        private void Update()
        {
            if (GetHourDuration() >= GameTime.Hours) return;
            exitDoor.SetActive(true);
            GameTime.PauseState(true);
            
        }

        public int GetHourDuration()
        {
            return startHour + transportDuration;
        }

        public void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player") && gameObject.CompareTag("ExitDoor"))
            {
                sceneController.ChangeScene(WorkingState.GetWorkingState() == false ? "SceneKantor" : "MainScene");
            }
        }
    }
}