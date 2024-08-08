using Player.Stats;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_SleepMinigame : MonoBehaviour
{
    public Slider slider;
    [SerializeField] private RectTransform _barBackground;
    [SerializeField] private RectTransform _barCenter;

    private float _moveRate = 1.05f;
    private float _maxVal;
    private float _minVal;
    private bool _isForward = true;

    protected float timer;

    // Start is called before the first frame update
    void Start()
    {
        slider.value = 0;
        _minVal = ((_barBackground.rect.width/2) - (_barCenter.rect.width/2))/_barBackground.rect.width;
        _maxVal = ((_barBackground.rect.width / 2) + (_barCenter.rect.width / 2))/_barBackground.rect.width;
        print(_maxVal);
    }

    // Update is called once per frame
    void Update()
    {
        timer = Time.deltaTime;

        if (slider.value <= slider.minValue)
        {
            _isForward = true;
        } else if (slider.value >= slider.maxValue)
        {
            _isForward = false;
        }

        if (_isForward)
        {
            slider.value += _moveRate * timer;
        } else
        {
            slider.value -= _moveRate * timer;
        }

        // If sleep succeeds
        if (_moveRate <= 0.05f)
        {
            PlayerStatsController.ReduceExhaustionPerSecond(timer);
        }
    }

    public void triggerInput()
    {
        if (slider.value >= _minVal && slider.value <= _maxVal) {
            if (_moveRate > 0.05f)
            {
                _moveRate -= 0.2f;
            }
        } else {
            if (_moveRate < 2.05f)
            {
                _moveRate += 0.2f;
            }
        }
        print(_moveRate);
    }
}
