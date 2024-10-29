using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace NPC
{
    public class NPCSpawner : MonoBehaviour
    {
        [SerializeField] private List<GameObject> npcPrefabsFront;
        [SerializeField] private List<GameObject> npcPrefabsBack;
        [SerializeField] private List<Transform> spawnPoint;

        private void Start()
        {
            SpawnNPC();
        }

        private void SpawnNPC()
        {
            int npcCount = Random.Range(0, spawnPoint.Count);
            
            float spawnChance = GetSpawnChance(npcCount);
            
            for (int i = 0; i < spawnPoint.Count; i++)
            {
                if (Random.value <= spawnChance)
                {
                    GameObject npcPrefabs;
                    if (i < 9)
                    {
                        npcPrefabs = npcPrefabsFront[GetRandomIndex(npcPrefabsFront)];
                    }
                    else
                    {
                        npcPrefabs = npcPrefabsBack[GetRandomIndex(npcPrefabsBack)];
                    }

                    Instantiate(npcPrefabs, spawnPoint[i]);
                }
                
            }
        }
        
        private float GetSpawnChance(int npcCount)
        {
            return npcCount switch
            {
                >= 1 and <= 10 => 1f,
                >= 11 and <= 15 => 0.5f,
                >= 16 when npcCount <= spawnPoint.Count => 0.3f,
                _ => 0f
            };
        }

        private int GetRandomIndex(List<GameObject> prefabsList)
        {
            return Random.Range(0, prefabsList.Count);
        }
    }
}
