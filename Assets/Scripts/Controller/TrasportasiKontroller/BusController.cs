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
        private void Awake()
        {
            startHour = GameTime.Hours;
            randomEvent.DoEvent();
            GameTime.PauseState(false);
        }

        private void Update()
        {
            if (GetHourDuration() >= GameTime.Hours) return;
            GameTime.PauseState(true);
            if (!Input.GetKeyDown(KeyCode.Space)) return;
            sceneController.ChangeScene(WorkingState.GetWorkingState() == false ? "SceneKantor" : "MainScene");
        }

        public int GetHourDuration()
        {
            return startHour + transportDuration;
        }
        
    }
}