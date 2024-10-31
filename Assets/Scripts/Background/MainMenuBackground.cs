using System;
using System.Collections.Generic;
using Transportasi;
using UnityEngine;

namespace Background
{
    public class MainMenuBackground : MonoBehaviour
    { 
        [SerializeField] private GameObject background;
        [SerializeField] private List<GameObject> backgroundElements;
        [SerializeField] private float backgroundSpeed;
        [SerializeField] private float backgroundElementsSpeed;
        [SerializeField] private Transform maxPosition;


        private void Update()
        {
            Slide();
            Teleport();
        }

        private void Slide()
        {
            var newPositionBackground = background.transform.position;
            newPositionBackground.x += -Time.deltaTime * backgroundSpeed;
            background.transform.position = newPositionBackground;

            for (int i = 0; i < backgroundElements.Count; i++)
            {
                var newPosition = backgroundElements[i].transform.position;
                newPosition.x += -Time.deltaTime * backgroundElementsSpeed;
                backgroundElements[i].transform.position = newPosition;
            }
        }

        private void Teleport()
        {
            for (int i = 0; i < backgroundElements.Count; i++)
            {
                if (backgroundElements[i].transform.position.x <= maxPosition.position.x)
                {
                    backgroundElements[i].transform.position = new Vector3(
                        -backgroundElements[i].transform.position.x,
                        backgroundElements[i].transform.position.y,
                        backgroundElements[i].transform.position.z 
                    );
                }
            }
        }
    }
}