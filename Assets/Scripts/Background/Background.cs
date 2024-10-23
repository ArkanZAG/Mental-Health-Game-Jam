using UnityEngine;

namespace Background
{
    public class Background : MonoBehaviour
    {
        [SerializeField] private GameObject background;
        [SerializeField] private int backgroundSpeed;
    
        void Update()
        {
            Slide();
        }

        private void Slide()
        {
            var newPosition = background.transform.position;
            newPosition.x += -Time.deltaTime * backgroundSpeed;
            background.transform.position = newPosition;
        }
    }
}
