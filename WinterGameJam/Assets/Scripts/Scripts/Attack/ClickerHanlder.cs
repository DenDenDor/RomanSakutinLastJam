using System.Collections;
using System;
using UnityEngine;

public class ClickerHanlder : MonoBehaviour
{
    [SerializeField] private float _countOfClicks;

    [SerializeField] private float _balanceValue = 5;
    [SerializeField] private float _additionalClick = 0.24f;

    private bool _isWorking = true;

    private float _rate = 0.5f;
    private float _minRate = 0;
    private float _maxRate = 1;

    private Timer _timer;
    [SerializeField] private BattleTimer _battleTimer;

    public float Rate => _rate;
    public float MaxRate => _maxRate;
    public float MinRate => _minRate;

    public event Action OnBattleOver;

    private void Start()
    {
        _timer = _battleTimer.Timer;
    }

    private void Update()
    {
        if (_isWorking)
        {
            if (IsRateLowerZero() || _timer.IsOver || IsRateBiggerMaxValue())
            {
                _isWorking = false;

                OnBattleOver?.Invoke();
            }

            Click();
            DecreaseRate();
            
        }

    }

    public bool IsRateLowerZero() => _rate < _minRate;

    public bool IsRateBiggerMaxValue() => _rate > _maxRate;

    private void Click()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _rate += _additionalClick;
        }
    }

    private void DecreaseRate() => _rate -= Time.deltaTime * _balanceValue;
}
