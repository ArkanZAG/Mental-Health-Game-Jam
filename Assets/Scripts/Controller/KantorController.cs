using System;
using DefaultNamespace;
using Player.Stats;
using RandomEvents;
using UI;
using Unity.VisualScripting;
using UnityEngine;

namespace Controller
{
    public class KantorController : MonoBehaviour
    {
        [SerializeField] private GameController gameController;
        [SerializeField] private SceneController sceneController;
        [SerializeField] private RandomEvent randomEvent;

        [SerializeField] private GameObject startWorkingScreen;

        [SerializeField] private KantorUI kantorUi;

        private bool isWorking;
        private bool isPaid;

        private int startWorkingHour;
        private int workDuration;
        
        private float stressTimer;
        private float workPerformance;
        private float startWorkingStress;
        private float startWorkingExhaustion;

        private float miniGameFinished;

        private void Start()
        {
            if (GameTime.Hours <= 9)
            {
                GameTime.SetGameTimeHours(9);
                startWorkingHour = GameTime.Hours;
            }
            startWorkingStress = PlayerStatsController.Stress;
            startWorkingExhaustion = PlayerStatsController.Exhaustion;
            gameController.SetGameSpeed(100);
            WorkPerformance();
            kantorUi.Display(false);
            startWorkingScreen.SetActive(true);
            isWorking = true;
            isPaid = false;
        }

        private void Update()
        {
            if (isWorking == true)
            {
                stressTimer += Time.deltaTime;
                AddStressPerMinutes();
            }
            if (GameTime.Hours <= 17) return;
            kantorUi.Display(true);
            startWorkingScreen.SetActive(false);
            isWorking = false;
            GameTime.PauseState(true);
            WorkingState.SetWorkingState(true);
            GetPaid();
            isPaid = true;
        }

        private void WorkPerformance()
        {
            workPerformance = 100 * (1 - (startWorkingStress - startWorkingExhaustion) / 200) + (PlayerStatsController.GetWorkMinigameAmount() * 5) -
                              LateWorkPenalty();
        }

        private float LateWorkPenalty()
        {
            var lateDuration = startWorkingHour - 9;
            float penalty = lateDuration * 10;
            return penalty;
        }

        private float WorkPayment()
        {
            var payment = 200 * (workPerformance / 100);
            return payment;
        }

        private void AddStressPerMinutes()
        {
            if (isWorking != true) return;
            if (stressTimer >= 60)
            {
                PlayerStatsController.AddStress(5);
                stressTimer = 0;
            }
            
        }

        private void GetPaid()
        {
            if (!isPaid)
            {
                PlayerStatsController.AddMoney(WorkPayment());
            }
            
        }
    }
}