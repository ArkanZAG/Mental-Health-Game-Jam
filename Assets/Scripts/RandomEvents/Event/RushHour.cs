using System.Collections.Generic;
using UnityEngine;

namespace RandomEvents.Event
{
    public class RushHour : RandomEvent
    {
        [SerializeField] private List<Transform> spawnPoint;
    }
}