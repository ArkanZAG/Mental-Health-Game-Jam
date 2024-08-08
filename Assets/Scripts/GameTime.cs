using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameTime
{
    private static int minutes;
    private static int hours;
    private static float realTime;

    public static int Minutes => minutes;
    public static int Hours => hours;

    public static void Update(float deltaTime)
    {
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
    }
    

    public static void AddHours(int timeAdded)
    {
        hours += timeAdded;
    }
}
