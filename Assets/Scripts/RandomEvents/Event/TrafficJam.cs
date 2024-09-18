using UnityEngine;

namespace RandomEvents.Event
{
    public class TrafficJam : RandomEvent
    {
        private float eventChance = 50f;
        
        public override void DoEvent()
        {
            var randomValue = Random.Range(0f, 100f);

            if (GameTime.Hours != 7 && GameTime.Hours != 8) return;
            if (randomValue > eventChance)
            {
                GameTime.AddHours(1);
            }
        }
    }
}