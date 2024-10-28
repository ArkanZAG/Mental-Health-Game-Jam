using Player.Stats;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_SleepMinigame : MonoBehaviour
{
    public Slider slider;
    [SerializeField] private RectTransform _barBackground;
    [SerializeField] private RectTransform _barCenter;
    [SerializeField] private Animator _buttonAnimator;
    [SerializeField] private TextMeshProUGUI _sleepIndicatorText;

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
        SpaceKeyInputHandler();
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
            PlayerStatsController.SetExhaustionPerSecond(-0.05f);
            _sleepIndicatorText.text = "Sleeping...";
        } else if (_moveRate >= 2.00){
            PlayerStatsController.SetExhaustionPerSecond(0.05f);
            _sleepIndicatorText.text = "Too distracted to sleep...";
        } else {
            PlayerStatsController.SetExhaustionPerSecond(0.05f);
            _sleepIndicatorText.text = "Trying to sleep...";
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

    private void SpaceKeyInputHandler() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            triggerInput();
            _buttonAnimator.SetTrigger("Down");
        }
    }
}
