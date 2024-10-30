using DefaultNamespace;
using RandomEvents;
using UnityEngine;

namespace Controller.Trasportasi
{
    public class BusController : MonoBehaviour
    {
        private int startHour;
        [SerializeField] private int hourDuration;
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
            if ((startHour + hourDuration) >= GameTime.Hours) return;
            GameTime.PauseState(true);
            if (!Input.GetKeyDown(KeyCode.Space)) return;
            sceneController.ChangeScene(WorkingState.GetWorkingState() == false ? "SceneKantor" : "MainScene");
        }
    }
}