using UnityEngine;

namespace RandomEvents
{
    public class RandomEvent : MonoBehaviour
    {
        public virtual void DoEvent()
        {
            Debug.Log("Event Happening");
        }
    }
}