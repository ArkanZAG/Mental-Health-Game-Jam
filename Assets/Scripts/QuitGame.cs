using System;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class QuitGame : MonoBehaviour
    {
        [SerializeField] private Button quitButton;

        private void Start()
        {
            quitButton.onClick.AddListener(Quit);
        }

        private void Quit()
        {
            Application.Quit();
        }
    }
}