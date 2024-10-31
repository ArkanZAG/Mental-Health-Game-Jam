using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats
{
   public float exhaustion;
   public float exhaustionPerSecond = 0.05f;
   public float minimumExhaustion = 0f;
   public float maximumExhaustion = 100f;
   
   public float stress;
   public float stressPerSecond;
   public float stressPerSecondModifier = 0.05f;
   public float minimumStress = 0f;
   public float maximumStress = 100f;
   
   
   public float money = 100f;
   
   // Mini Game related attributes
   public IdleGameStats idleGameStats = new IdleGameStats();
   public WorkGameStats workGameStats = new WorkGameStats();
}
