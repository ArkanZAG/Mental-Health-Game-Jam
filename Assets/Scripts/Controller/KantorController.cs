using System;
using DefaultNamespace;
using Player.Stats;
using RandomEvents;
using UI;
using UnityEngine;

namespace Controller
{
    public class KantorController : MonoBehaviour
    {
        [SerializeField] private GameController gameController;
        [SerializeField] private SceneController sceneController;
        [SerializeField] private RandomEvent randomEvent;

        [SerializeField] private KantorUI kantorUi;
        [SerializeField] private GameObject startScreen;

        private int startWorkingHour;
        private int workDuration;
        
        private float workPerformance;
        private float startWorkingStress;
        private float startWorkingExhaustion;

        private float miniGameFinished;

        private void Start()
        {
            startWorkingHour = GameTime.Hours;
            startWorkingStress = PlayerStatsController.Stress;
            startWorkingExhaustion = PlayerStatsController.Exhaustion;
            WorkPerformance();
            startScreen.SetActive(true);
            kantorUi.Display(false);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameTime.PauseState(false);
                gameController.SetGameSpeed(100f);
                startScreen.SetActive(false);
            }
            if (GameTime.Hours <= 17) return;
            kantorUi.Display(true);
            GameTime.PauseState(true);
            WorkingState.SetWorkingState(true);
            PlayerStatsController.AddMoney(WorkPayment());
        }

        private void WorkPerformance()
        {
            workPerformance = 100 * (1 - (startWorkingStress - startWorkingExhaustion) / 200) + (miniGameFinished * 5) -
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
    }
}