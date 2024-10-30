using DefaultNamespace;
using UnityEngine;

namespace Controller.TrasportasiKontroller
{
    public class TrainController : Transportasi.Transportasi
    {
        private int startHour;
        [SerializeField] private int hourDuration;
        [SerializeField] private GameController gameController;
        [SerializeField] private SceneController sceneController;
        [SerializeField] private Collider col;
        private void Awake()
        {
            startHour = GameTime.Hours;
            GameTime.PauseState(false);
        }

        private void Update()
        {
            if ((startHour + hourDuration) > GameTime.Hours) return;
            gameController.SetGameSpeed(0f);
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.tag == "Player")
            {
                sceneController.ChangeScene(WorkingState.GetWorkingState() == false ? "SceneKantor" : "MainScene");
            }
        }
    }
}
