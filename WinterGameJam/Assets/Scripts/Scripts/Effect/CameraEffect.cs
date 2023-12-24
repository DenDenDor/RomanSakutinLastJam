using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEffect : MonoBehaviour
{
    [SerializeField] private CameraFilterPack_Blur_Tilt_Shift_Hole _camera;
    [SerializeField] private CameraFilterPack_TV_Vignetting _vignetting;

    [SerializeField] private ClickerHanlder _clickerHanlder;
    [SerializeField] private AnimationCurve _blur;
    [SerializeField] private AnimationCurve _vignettingCurve;

    [SerializeField] private float _effectBlur = 4;
    [SerializeField] private float _effectVignetting = 4;

    private int _maxCountOfClicks = 7;
    private int _countOfClicks = 0;


    private float _startTime;
    [SerializeField] private float _maxTime = 1.5f;

    private Timer _timer;
    

    private void Start()
    {
        _clickerHanlder.OnClick += IncreaseClickCount;
    }

    private void IncreaseClickCount()
    {
        _countOfClicks++;

        if (_countOfClicks >= _maxCountOfClicks)
        {
            InitializeTimer();
            _countOfClicks = 0;
        }
    }
    private void InitializeTimer() => _timer = new Timer(_startTime, _maxTime);

    private void Update()
    {
        if (_timer != null)
        {
            _timer.IncreaseTime();

            _camera.Amount = _blur.Evaluate(_timer.CurrentTime) * _effectBlur;
            _vignetting.VignettingColor.a = _vignettingCurve.Evaluate(_timer.CurrentTime) * _effectVignetting;

            if (_timer.IsOver)
            {
                _timer = null;
            }
        }
    }

    private void OnDisable()
    {
        _clickerHanlder.OnClick -= IncreaseClickCount;
    }
}
