using DefaultNamespace;
using RandomEvents;
using UnityEngine;

namespace Controller.TrasportasiKontroller
{
    public class TaxiController : Transportasi.Transportasi
    {
        private int startHour;
        [SerializeField] private int hourDuration;
        [SerializeField] private RandomEvent randomEvent;
        [SerializeField] private SceneController sceneController;
        [SerializeField] private GameObject arriveUI;
        
        private void Awake()
        {
            GameTime.PauseState(true);
            startHour = GameTime.Hours;
            randomEvent.DoEvent();
            GameTime.PauseState(false);
            arriveUI.SetActive(false);
        }
        
        private void Update()
        {
            if ((startHour + hourDuration) > GameTime.Hours) return;
            GameTime.PauseState(true);
            arriveUI.SetActive(true);
            if (!Input.GetKeyDown(KeyCode.Space)) return;
            sceneController.ChangeScene(WorkingState.GetWorkingState() == false ? "SceneKantor" : "MainScene");
        }
    
    }
}