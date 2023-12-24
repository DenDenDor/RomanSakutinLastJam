using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseHandler : MonoBehaviour
{
    private float _startTime;
    [SerializeField] private float _maxTime = 1.5f;

    [SerializeField] private AnimationCurve _curve;
    [SerializeField] private float _effect;

    [SerializeField] private CameraFilterPack_AAA_Blood_Plus _camera;

    private Timer _timer;

    public void Lose()
    {
        InitializeTimer();
    }

    private void InitializeTimer() => _timer = new Timer(_startTime, _maxTime);

    private void Update()
    {
        if (_timer != null)
        {
            _timer.IncreaseTime();
            _camera.Blood_10 = _timer.CurrentTime * _effect;

            if (_timer.IsOver)
            {
                _timer = null;
            }
        }
    }
}
