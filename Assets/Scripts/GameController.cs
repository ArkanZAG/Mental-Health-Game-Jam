using System.Collections;
using System.Collections.Generic;
using Player.Stats;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private float gameSpeed = 1;
    void Update()
    {
        GameTime.Update(Time.deltaTime * gameSpeed);
        PlayerStatsController.Update(Time.deltaTime * gameSpeed);
        
        Debug.Log("Jam : "+GameTime.Hours+" Menit : " + GameTime.Minutes + " Exhaustion : " + PlayerStatsController.Exhaustion );
    }
}
