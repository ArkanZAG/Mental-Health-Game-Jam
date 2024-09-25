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

        private void Start()
        {
            taxiSceneButton.onClick.AddListener(ChangeSceneTaxi);
            trainSceneButton.onClick.AddListener(ChangeSceneTrain);
            busSceneButton.onClick.AddListener(ChangeSceneBus);
        }
        private void ChangeSceneTaxi()
        {
            PlayerStatsController.AddMoney(-150);
            sceneController.ChangeScene("TransportasiTaxi");
        }
        private void ChangeSceneTrain()
        {
            PlayerStatsController.AddMoney(-100);
            sceneController.ChangeScene("TransportasiKereta");
        }
        private void ChangeSceneBus()
        {
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

        private void Display()
        {
            if (GameTime.Hours >= 8)
            {
                homeSceneUI.SetActive(true);
                GameTime.PauseState(true);
                PlayerStatsController.SetExhaustionPerSecond(0f);
            }
        }
    }
}
