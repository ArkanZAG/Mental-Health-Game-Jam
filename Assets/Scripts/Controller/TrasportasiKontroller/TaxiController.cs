using DefaultNamespace;
using RandomEvents;
using UnityEngine;

namespace Controller.TrasportasiKontroller
{
    public class TaxiController : Transportasi.TransportationController
    {
        private int startHour;
        [SerializeField] private RandomEvent randomEvent;
        [SerializeField] private SceneController sceneController;

        [SerializeField] private GameObject backgroundSiang;
        [SerializeField] private GameObject backgroundMalam;
        
        private void Awake()
        {
            GameTime.PauseState(true);
            startHour = GameTime.Hours;
            randomEvent.DoEvent();
            GameTime.PauseState(false);
        }
        
        private void Update()
        {
            if ((GetHourDuration()) > GameTime.Hours) return;
            GameTime.PauseState(true);
            if (!Input.GetKeyDown(KeyCode.Space)) return;
            sceneController.ChangeScene(WorkingState.GetWorkingState() == false ? "SceneKantor" : "Rumah");
        }
        
        public int GetHourDuration()
        {
            return startHour + transportDuration;
        }
    
    }
}
