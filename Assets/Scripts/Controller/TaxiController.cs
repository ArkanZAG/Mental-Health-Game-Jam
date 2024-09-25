using DefaultNamespace;
using RandomEvents;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Controller
{
    public class TaxiController : MonoBehaviour
    {
        private int startHour;
        [SerializeField] private int hourDuration;
        [SerializeField] private RandomEvent randomEvent;
        [SerializeField] private SceneController sceneController;
        
        private void Awake()
        {
            GameTime.PauseState(true);
            startHour = GameTime.Hours;
            randomEvent.DoEvent();
        }
        
        private void Update()
        {
            if ((startHour + hourDuration) >= GameTime.Hours) return;
            GameTime.PauseState(true);
            if (!Input.GetKeyDown(KeyCode.Space)) return;
            sceneController.ChangeScene(WorkingState.GetWorkingState() == false ? "SceneKantor" : "MainScene");
        }
    
    }
}
