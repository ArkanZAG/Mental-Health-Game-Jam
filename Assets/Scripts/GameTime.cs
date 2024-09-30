using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameTime
{
    private static int minutes;
    private static int hours = 4;
    private static float realTime;
    private static int dayCount = 1;
    private static bool isPaused = false;

    public static int Minutes => minutes;
    public static int Hours => hours;
    public static int DayCount => dayCount;

    public static void Update(float deltaTime)
    {
        if (isPaused) return;
        
        realTime += deltaTime;
        
        if (realTime >= 1)
        {
            minutes += 1;
            realTime -= 1f;
            if (minutes >= 60)
            {
                hours += 1;
                minutes -= 60;
            }
        }

        if (hours != 24) return;
        hours = 0;
        dayCount += 1;
    }
    

    public static void AddHours(int timeAdded)
    {
        hours += timeAdded;
    }

    public static void PauseState(bool value)
    {
        isPaused = value;
    }

    public static void SetGameTimeHours(int value)
    {
        hours = value;
    }

    public static bool GetPauseState()
    {
        return isPaused;
    }
}
