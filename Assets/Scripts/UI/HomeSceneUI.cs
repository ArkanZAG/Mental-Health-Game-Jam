using System;
using System.Collections;
using System.Collections.Generic;
using Controller;
using Player.Stats;
using UnityEngine;
using UnityEngine.UI;

public class HomeSceneUI : MonoBehaviour
{

    [SerializeField] private SceneController sceneController;
    
    [SerializeField] private Button taxiSceneButton;
    [SerializeField] private Button trainSceneButton;
    [SerializeField] private Button busSceneButton;
    
    [SerializeField] private GameObject homeSceneUI;

    private void Start()
    {
        taxiSceneButton.onClick.AddListener(ChangeSceneTaxi);
        trainSceneButton.onClick.AddListener(ChangeSceneTrain);
        trainSceneButton.onClick.AddListener(ChangeSceneBus);
    }
    private void ChangeSceneTaxi()
    {
        sceneController.ChangeScene("TransportasiTaxi");
    }
    private void ChangeSceneTrain()
    {
        sceneController.ChangeScene("TransportasiKereta");
    }
    private void ChangeSceneBus()
    {
        sceneController.ChangeScene("TrasportasiBis");
    }
    
    private void Update()
    {
        Display();
    }

    private void Awake()
    {
        HideUI();
    }

    private void HideUI()
    {
        homeSceneUI.SetActive(false);
    }

    private void Display()
    {
        if (GameTime.Hours >= 8)
        {
            homeSceneUI.SetActive(true);
            GameTime.PauseState(true);
            PlayerStatsController.SetExhaustionPerSecond(0f);
        }
    }
}
