using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class HandlerEndingBattle : MonoBehaviour
{
    [SerializeField] private ClickerHanlder _clickerHanlder;
    [SerializeField] private BattleTimer _battleTimer;


    [SerializeField] private WinHanlder _winHanlder;
    [SerializeField] private LoseHandler _loseHandler;
    [SerializeField] private OverTimeHanlder _overTimeHanlder;

    private void Start()
    {
        _clickerHanlder.OnBattleOver += ActivateEnding;
    }

    public void ActivateEnding()
    {
        if (_clickerHanlder.IsRateBiggerMaxValue())
        {
            _winHanlder.Win();
        }
        else if (_clickerHanlder.IsRateLowerZero())
        {
            _loseHandler.Lose();
        }
        else if (_battleTimer.Timer.IsOver)
        {
            _overTimeHanlder.TimeOver();
        }
    }


    private void OnDisable()
    {
        _clickerHanlder.OnBattleOver += ActivateEnding;
    }
}
