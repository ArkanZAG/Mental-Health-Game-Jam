using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Player.Stats;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Commuting : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private TransportasionType transportasionType;
    
    public enum TransportasionType
    {
        Taxi,
        Bus,
        Train
    }
    
    public void TransportationChoice()
    {
        switch (transportasionType)
        {
            case TransportasionType.Taxi:
                PlayerStatsController.AddMoney( -150);
                SceneManager.LoadScene("TransportasiTaxi");
                break;
            case TransportasionType.Train:
                PlayerStatsController.AddMoney( -100);
                SceneManager.LoadScene("TransportasiKereta");
                break;
            case TransportasionType.Bus:
                PlayerStatsController.AddMoney( -50);
                SceneManager.LoadScene("TransportasiBis");
                break;
            default:
                break;
        }
    }

    private void Awake()
    {
        button.onClick.AddListener(TransportationChoice);
    }
}
