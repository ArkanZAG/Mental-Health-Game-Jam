using RandomEvents;
using UnityEngine;

namespace Controller
{
    public class RandomEventController : MonoBehaviour
    {
        [SerializeField] private RandomEvent randomEvent;

        public void DoEvent(RandomEvent randEvent)
        {
            randomEvent = randEvent;
            randomEvent.DoEvent();
        }
    }
}
