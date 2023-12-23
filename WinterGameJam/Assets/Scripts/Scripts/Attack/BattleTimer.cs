using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleTimer : MonoBehaviour
{
    [SerializeField] private float _startTime = 1;
    [SerializeField] private float _maxTime = 40;

    private Timer _timer;

    public Timer Timer  => _timer;

    private void Awake()
    {
        _timer = new Timer(_startTime, _maxTime);
    }

    private void Update()
    {
        _timer.IncreaseTime();
    }
}
