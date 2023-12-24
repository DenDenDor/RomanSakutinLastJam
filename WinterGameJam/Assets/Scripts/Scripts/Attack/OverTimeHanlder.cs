using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverTimeHanlder : MonoBehaviour
{
    private float _averageRate = 0.5f; 
    [SerializeField] private ClickerHanlder _clickerHanlder;

    [SerializeField] private WinHanlder _winHanlder;
    [SerializeField] private LoseHandler _loseHanlder;

    public void TimeOver()
    {
        Debug.Log("Time is over...");

        if (_clickerHanlder.Rate > _averageRate)
        {
            _winHanlder.Win();
        }
        else
        {
            _loseHanlder.Lose();
        }
    }
}
