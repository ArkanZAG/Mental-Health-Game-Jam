using UnityEngine;

namespace RandomEvents.Event
{
    public class TrafficJam : RandomEvent
    {
        private float eventChance = 50f;
        
        public override void DoEvent()
        {
            Debug.Log("Traffijam");
            var randomValue = Random.Range(0f, 100f);

            if (GameTime.Hours != 7 && GameTime.Hours != 8) return;
            if (randomValue >= eventChance)
            {
                Debug.Log("Traffic Jam Initiated");
                GameTime.AddHours(1);
            }
        }
    }
}