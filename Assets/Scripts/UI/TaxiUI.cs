using System;
using System.Collections;
using System.Collections.Generic;
using Player.Stats;
using UnityEngine;
using UnityEngine.UI;


public class TaxiUI : MonoBehaviour
{
    [SerializeField] private Button workButton;
    [SerializeField] private Button restButton;
    [SerializeField] private Button playMiniGameButton;

    [SerializeField] private GameObject holder;

    private void Start()
    {
        workButton.onClick.AddListener(StartTimer);
        //restButton.onClick.AddListener();
        //playMiniGameButton.onClick.AddListener();
        
        Display();
    }

    public void Display()
    {
        holder.SetActive(true);
    }

    public void StartTimer()
    {
        GameTime.PauseState(false);
        PlayerStatsController.SetExhaustionPerSecond(1);
    }
}
