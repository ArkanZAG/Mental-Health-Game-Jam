using Player.Stats;
using UnityEngine;

namespace RandomEvents.Event
{
    public class Overslept : RandomEvent
    {
        private float eventChance = 25f;
        
        public override void DoEvent()
        {
            var randomValue = Random.Range(0f, 100f);

            if (GameTime.Hours != 4 || !(PlayerStatsController.Exhaustion >= 50)) return;
            if (randomValue <= eventChance)
            {
                GameTime.AddHours(1);
                PlayerStatsController.AddExhaustion(-25);
            }
        }
    }
}