using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Background
{
    public class Background : MonoBehaviour
    {
        [SerializeField] private GameObject background;
        [SerializeField] private GameObject foreground;
        [SerializeField] private int backgroundSpeed;
        [SerializeField] private float foregroundSpeed;

        [SerializeField] private Transform maxPosition;

        [SerializeField] private List<GameObject> backgroundElements;
        
    
        void Update()
        {
            Slide();
            TeleportBackground();
        }

        private void Slide()
        {
            
            var newPositionForeground = foreground.transform.position;
            newPositionForeground.x += -Time.deltaTime * foregroundSpeed;
            foreground.transform.position = newPositionForeground;
            
            for (int i = 0; i < backgroundElements.Count; i++)
            {
                var newPosition = backgroundElements[i].transform.position;
                newPosition.x += -Time.deltaTime * backgroundSpeed;
                backgroundElements[i].transform.position = newPosition;
            }
        }

        private void TeleportBackground()
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
