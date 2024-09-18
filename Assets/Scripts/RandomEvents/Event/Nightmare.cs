using System;
using Player.Stats;
using UnityEngine;
using Random = UnityEngine.Random;

namespace RandomEvents.Event
{
    public class Nightmare : RandomEvent
    {
        private float chanceBase = 10f;
        private float chanceMax = 50f;
        private float GetNightmareChance()
        {
            var chance = chanceBase + ((chanceMax - chanceBase) / 100) * PlayerStatsController.Exhaustion;
            return chance;
        }

        public override void DoEvent()
        {
            var randomChance = Random.Range(0f, 100f);
            
            if (randomChance > GetNightmareChance())
            {
                PlayerStatsController.AddExhaustion(20f);
            }
        }
    }
}