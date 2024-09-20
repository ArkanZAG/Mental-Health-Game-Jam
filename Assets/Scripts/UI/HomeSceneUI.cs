using System;
using System.Collections;
using System.Collections.Generic;
using Controller;
using UnityEngine;
using UnityEngine.UI;

public class HomeSceneUI : MonoBehaviour
{

    [SerializeField] private SceneController sceneController;
    
    [SerializeField] private Button taxiSceneButton;
    [SerializeField] private Button trainSceneButton;
    [SerializeField] private Button busSceneButton;

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
}
