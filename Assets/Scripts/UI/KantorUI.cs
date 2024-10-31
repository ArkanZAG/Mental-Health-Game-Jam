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

        public void Display(bool value)
        {
            holder.SetActive(value);
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
        
        //note to self, yang harusnya ganti scene bukan UI tapi controller. sidenote : currenty unable to solve how to do that
    }
}