using System;
using Player.Stats;
using Unity.VisualScripting;
using UnityEngine;

namespace NPC
{
    public class NonPlayableCharacter : MonoBehaviour
    {
        private bool isColliderColliding;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player") && !isColliderColliding)
            {
                PlayerStatsController.AddStressPerSecond(1f);
                isColliderColliding = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player") && isColliderColliding)
            {
                PlayerStatsController.AddStressPerSecond(0f);
                isColliderColliding = false;
            }
        }
    }
}