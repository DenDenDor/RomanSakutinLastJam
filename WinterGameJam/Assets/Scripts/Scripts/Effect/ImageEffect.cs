using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageEffect : MonoBehaviour
{
    [SerializeField] private ClickerHanlder _clickerHanlder;
    [SerializeField] private Transform _imageEnemy;
    [SerializeField] private Transform _imagePlayer;
    [SerializeField] private float _maxScale;
    [SerializeField] private float _minScale;

    private void Update()
    {
        _imagePlayer.localScale = Vector3.one * Mathf.Lerp(_minScale, _maxScale, _clickerHanlder.Rate);
        _imageEnemy.localScale = Vector3.one * Mathf.Lerp(_maxScale, _minScale, _clickerHanlder.Rate);
    }
}
