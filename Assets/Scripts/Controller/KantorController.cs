using System;
using DefaultNamespace;
using Player.Stats;
using RandomEvents;
using UnityEngine;

namespace Controller
{
    public class KantorController : MonoBehaviour
    {
        [SerializeField] private GameController gameController;
        [SerializeField] private SceneController sceneController;
        [SerializeField] private RandomEvent randomEvent;

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
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                gameController.SetGameSpeed(5f);
            }
            if (GameTime.Hours < 9) return;
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