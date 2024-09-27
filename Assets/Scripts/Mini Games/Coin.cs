using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Coin : MonoBehaviour
{
    [SerializeField] Animator coinAnimator;
    private float _timer = 0f;
    private float _aliveDuration = 2f;

    void Start() {
        _timer = 0.0f;
    }

    void Update() {
        _timer += Time.deltaTime;

        if (_timer >= _aliveDuration) {
            CoinPool.ReleaseToPool(gameObject);
            _timer = 0;
        }
    }

    void OnEnable() {
        coinAnimator.Play("CoinMoveUp");
        
    }
}
