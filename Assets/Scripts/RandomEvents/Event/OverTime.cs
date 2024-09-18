using UnityEngine;

namespace RandomEvents.Event
{
    public class OverTime : RandomEvent
    {
        private float eventChance = 10f;
        
        public override void DoEvent()
        {
            var randomValue = Random.Range(0f, 100f);
            
            if (randomValue < eventChance)
            {
                GameTime.AddHours(1);
            }
        }
    }
}