using Controller;
using Player.Stats;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class HomeSceneUI : MonoBehaviour
    {

        [SerializeField] private SceneController sceneController;
    
        [SerializeField] private Button taxiSceneButton;
        [SerializeField] private Button trainSceneButton;
        [SerializeField] private Button busSceneButton;
    
        [SerializeField] private GameObject homeSceneUI;
        [SerializeField] private GameObject reportCard;
        [SerializeField] private GameObject decisionUI;

        private void Start()
        {
            taxiSceneButton.onClick.AddListener(ChangeSceneTaxi);
            trainSceneButton.onClick.AddListener(ChangeSceneTrain);
            busSceneButton.onClick.AddListener(ChangeSceneBus);
            reportCard.SetActive(true);
            

            if (GameTime.Hours == 7)
            {
                decisionUI.SetActive(true);
                GameTime.PauseState(true);
            }
        }
        private void ChangeSceneTaxi()
        {
            if (!(PlayerStatsController.Money >= 150)) return;
            PlayerStatsController.AddMoney(-150);
            sceneController.ChangeScene("TransportasiTaxi");
        }
        private void ChangeSceneTrain()
        {
            if (!(PlayerStatsController.Money >= 100)) return;
            PlayerStatsController.AddMoney(-100);
            sceneController.ChangeScene("TransportasiKereta");
        }
        private void ChangeSceneBus()
        {
            if (!(PlayerStatsController.Money >= 50)) return;
            PlayerStatsController.AddMoney(-50);
            sceneController.ChangeScene("TransportasiBis");
        }
    
        private void Update()
        {
            Display();
        }

        private void Awake()
        {
            HideUI();
        }

        private void HideUI()
        {
            homeSceneUI.SetActive(false);
        }

        public void Display()
        {
            if (GameTime.DayCount >= 7) return;
            if (GameTime.Hours < 5 || GameTime.Hours >= 18) return;
            homeSceneUI.SetActive(true);
            GameTime.PauseState(true);
            PlayerStatsController.SetExhaustionPerSecond(0f);

        }
    }
}
