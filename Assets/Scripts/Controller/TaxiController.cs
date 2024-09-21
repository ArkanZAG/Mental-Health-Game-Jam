using RandomEvents;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Controller
{
    public class TaxiController : MonoBehaviour
    {
        private int startHour;
        [SerializeField] private int hourDuration;
        [SerializeField] private RandomEventController randomEventController;
        [SerializeField] private SceneController sceneController;
        [SerializeField] private RandomEvent randomEvent;
        [SerializeField] private TaxiUI taxiUiController;
        
        private void Awake()
        {
            GameTime.PauseState(true);
            startHour = GameTime.Hours;
            randomEventController.DoEvent(randomEvent);
        }
        
        private void Update()
        {
            if ((startHour + hourDuration) <= GameTime.Hours)
            {
                GameTime.PauseState(true);
                sceneController.ChangeScene("SceneKantor");
            }
        }
    
    }
}
