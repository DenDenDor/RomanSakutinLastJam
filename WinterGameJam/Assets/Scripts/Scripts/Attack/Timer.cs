using System.Collections;
using System;
using System.Linq;
using UnityEngine;

public class Timer
{
    private bool _isOver = false;

    private float _currentTime;
    private readonly float _maxTime;

    public float CurrentTime => _currentTime;
    public bool IsOver => _isOver;

    public Timer(float currentTime, float maxTime)
    {
        _currentTime = currentTime;
        _maxTime = maxTime;
    }

    public void IncreaseTime()
    {
        
        if (_currentTime < _maxTime)
        {
            _currentTime += Time.deltaTime;
            return;
        }
        else
        {
            _isOver = true;
        }
    }
}
