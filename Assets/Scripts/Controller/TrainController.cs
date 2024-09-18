using UnityEngine;

namespace Controller
{
    public class TrainController : MonoBehaviour
    {
        private int startHour;
        [SerializeField] private int hourDuration;
        [SerializeField] private GameController gameController;
        private void Awake()
        {
            startHour = GameTime.Hours;
        
        }

        private void Update()
        {
            if ((startHour + hourDuration) <= GameTime.Hours)
            {
                gameController.SetGameSpeed(0f);
            }
        }
    }
}
