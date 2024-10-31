using System;
using Controller;
using Transportasi;
using UnityEngine;

namespace DefaultNamespace
{
    public class ExitDoor : MonoBehaviour
    {
        [SerializeField] private GameObject exitDoor;
        [SerializeField] private SceneController sceneController;
        
        public void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player") && gameObject.CompareTag("ExitDoor"))
            {
                sceneController.ChangeScene(WorkingState.GetWorkingState() == false ? "SceneKantor" : "MainScene");
            }
        }
    }
}