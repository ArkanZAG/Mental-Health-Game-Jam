using System;
using System.Collections;
using System.Collections.Generic;
using Player.Stats;
using TMPro;
using UnityEngine;
using UnityEngine.Pool;

public class CoinPool : MonoBehaviour
{
    public ObjectPool<GameObject> pool;
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private GameObject coinSpawnContainer;

    public bool CheckCollection = true;
    public int maxCapacity = 5;
    private bool isLeft = true;
    public static Action<GameObject> ReleaseToPool;

    void Awake() {
        pool = new ObjectPool<GameObject>(
            CreateCoin, OnGetCoin, OnReleaseCoin, null, CheckCollection, 5, maxCapacity
        );
        ReleaseToPool = delegate (GameObject coin) {
        if (pool != null) {
            pool.Release(coin);
        }
    };
    }

    public GameObject CreateCoin() {
        var pooledCoinObject = Instantiate(coinPrefab, coinSpawnContainer.transform);
        
        return pooledCoinObject;
    }

    public void OnReleaseCoin(GameObject coinObject) {
        coinObject.SetActive(false);
    }

    public void OnGetCoin(GameObject coinObject) {
        Debug.Log("coin spawned!");

        coinObject.SetActive(true);
        var leftVector = new Vector2(-50, -25);
        var rightVector = new Vector2(50, -25);
        if (isLeft) {
            coinObject.GetComponent<RectTransform>().localPosition = leftVector;
            Debug.Log(coinObject.GetComponent<RectTransform>().anchoredPosition);
        } else {
            Debug.Log(isLeft);
            coinObject.GetComponent<RectTransform>().localPosition = rightVector;
        }
        coinObject.GetComponent<RectTransform>().ForceUpdateRectTransforms();
        isLeft = !isLeft;
    }

    public void SpawnCoin() {
        PlayerStatsController.IncrementIdleCoin();
        pool.Get();
    }

    public void InvokeSpawnCoin() {
        Debug.Log("spawn coin!");
        InvokeRepeating("SpawnCoin", 0, 0.5f);
    }
}
