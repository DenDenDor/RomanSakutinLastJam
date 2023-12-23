using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MoverSlider : MonoBehaviour, IEventedByBattle
{
    [SerializeField] private Slider _slider;
    [SerializeField] private ClickerHanlder _clickerHanlder;

    private void Update()
    {
        MoveSlider();
    }

    private void MoveSlider()
    {
       _slider.value = _clickerHanlder.Rate;
    }

    public void Do()
    {
        
    }
}
