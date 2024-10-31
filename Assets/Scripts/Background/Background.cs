using System.Collections.Generic;
using Transportasi;
using UnityEngine;
using UnityEngine.Serialization;

namespace Background
{
    public class Background : MonoBehaviour
    {
        [SerializeField] private GameObject background;
        [SerializeField] private GameObject foreground;
        [SerializeField] private TransportationController transportasi;
        [SerializeField] private int foregroundSpeed;
        [SerializeField] private float backgroundSpeed;

        [SerializeField] private GameObject noonBackground;
        [SerializeField] private GameObject afterNoonBackground;
        [SerializeField] private GameObject nightBackground;

        [SerializeField] private Transform maxPosition;

        [SerializeField] private List<GameObject> foregroundElements;
        
    
        void Update()
        {
            Slide();
            TeleportBackground();
        }

        private void Slide()
        {
            var newPositionBackground = foreground.transform.position;
            newPositionBackground.x += -Time.deltaTime * backgroundSpeed;
            foreground.transform.position = newPositionBackground;
            
            for (int i = 0; i < foregroundElements.Count; i++)
            {
                var newPosition = foregroundElements[i].transform.position;
                newPosition.x += -Time.deltaTime * foregroundSpeed;
                foregroundElements[i].transform.position = newPosition;
            }
        }

        private void TeleportBackground()
        {
            for (int i = 0; i < foregroundElements.Count; i++)
            {
                if (foregroundElements[i].transform.position.x <= maxPosition.position.x)
                {
                    foregroundElements[i].transform.position = new Vector3(
                        -foregroundElements[i].transform.position.x,
                        foregroundElements[i].transform.position.y,
                        foregroundElements[i].transform.position.z 
                    );
                }
            }
        }
    }
}
