using System;
using Controller;
using Player.Stats;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class KantorUI : MonoBehaviour
    {
        [SerializeField] private SceneController sceneController;
        
        [SerializeField] private GameObject startingUI;
        [SerializeField] private GameObject holder;
        [SerializeField] private Button taxiButton;
        [SerializeField] private Button trainButton;
        [SerializeField] private Button busButton;

        private void Start()
        {
            taxiButton.onClick.AddListener(ChangeSceneTaxi);
            trainButton.onClick.AddListener(ChangeSceneTrain);
            busButton.onClick.AddListener(ChangeSceneBus);
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
    }
}