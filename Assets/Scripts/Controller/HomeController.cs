using System;
using System.Collections;
using System.Collections.Generic;
using Controller;
using DefaultNamespace;
using Player.Stats;
using RandomEvents;
using UI;
using UnityEngine;

public class HomeController : MonoBehaviour
{
    [SerializeField] private RandomEvent randomEvent;
    [SerializeField] private HomeSceneUI homeSceneUI;
    [SerializeField] private GameController gameController;

    private int arriveHomeTime;
    private int wakeUpTime = 4;

    private bool hasSlept;
    
    void Start()
    {
        WorkingState.SetWorkingState(false);
        GameTime.PauseState(false);
        PlayerStatsController.SaveInitialStats();
        PlayerStatsController.SetExhaustionPerSecond(0f);
        PlayerStatsController.SetStressPerSecond(0f);
        if (GameTime.DayCount > 1)
        {
            arriveHomeTime = GameTime.Hours;
            PlayerStatsController.ResetWorkMinigameAmount();
        }
    }

    private void Update()
    {
        if (GameTime.Hours >= 18 && GameTime.Hours < 20)
        {
            if (hasSlept) return;
            GetSomeRest();
            hasSlept = true;
        }
        else if(GameTime.Hours >= 20 && GameTime.Hours < 4 )
        {
            if (hasSlept) return;
            GoToSleep();
            hasSlept = true;
        }
        else
        {
            WakeUp();
        }
    }

    private int GetRestDuration()
    {
        int sleepDuration = arriveHomeTime - 20;
        return sleepDuration;
    }

    private int GetSleepDuration()
    {
        int sleepDuration;
        
        if (arriveHomeTime >= 4)
        {
            sleepDuration = (24 - arriveHomeTime) + wakeUpTime;
        }
        else
        {
            sleepDuration = wakeUpTime - arriveHomeTime;
        }

        return sleepDuration;
    }

    private void GoToSleep()
    {
        Debug.Log("Player is Sleeping");
        gameController.SetGameSpeed(5f);
        PlayerStatsController.AddExhaustion(-(12.5f * GetSleepDuration()));
        
    }

    private void GetSomeRest()
    {
        Debug.Log("Player is Resting");
        gameController.SetGameSpeed(5f);
        PlayerStatsController.AddStress(-(5 * GetRestDuration()));
    }

    private void WakeUp()
    {
        hasSlept = false;
    }
}
