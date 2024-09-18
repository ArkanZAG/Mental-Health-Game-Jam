using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TestScript
{
    public class SceneChanger : MonoBehaviour
    {
        public void OnTriggerEnter(Collider other)
        {
            SceneManager.LoadScene("SceneKantor");
        }
    }
}