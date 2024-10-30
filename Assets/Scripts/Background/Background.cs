using System.Collections.Generic;
using Transportasi;
using UnityEngine;
using UnityEngine.Serialization;

namespace Background
{
    public class Background : MonoBehaviour
    {
        [SerializeField] private GameObject foreground;
        [SerializeField] private GameObject background;
        [SerializeField] private TransportationController transportasi;
        [SerializeField] private int foregroundSpeed;
        [SerializeField] private float backgroundSpeed;

        [SerializeField] private GameObject noonBackground;
        [SerializeField] private GameObject afterNoonBackground;
        [SerializeField] private GameObject nightBackground;

        [SerializeField] private Transform maxPosition;

        [SerializeField] private List<GameObject> backgroundElements;
        
    
        void Update()
        {
            Slide();
            TeleportBackground();
        }

        private void Slide()
        {
            var newPositionBackground = background.transform.position;
            newPositionBackground.x += -Time.deltaTime * backgroundSpeed;
            background.transform.position = newPositionBackground;
            
            for (int i = 0; i < backgroundElements.Count; i++)
            {
                var newPosition = backgroundElements[i].transform.position;
                newPosition.x += -Time.deltaTime * foregroundSpeed;
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
