using System;
using Player.Stats;
using Unity.VisualScripting;
using UnityEngine;

namespace NPC
{
    public class NonPlayableCharacter : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                PlayerStatsController.SetExhaustionPerSecond(1f);
            }
            else
            {
                
            }
        }
    }
}