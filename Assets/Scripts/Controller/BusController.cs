using UnityEngine;
using UnityEngine.SceneManagement;

namespace Controller
{
    public class BusController : MonoBehaviour
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