using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class TabEffect : MonoBehaviour
{
    [SerializeField] private ClickerHanlder _clickerHanlder;
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private Camera _camera;
    [SerializeField] private float _destroyTime = 3;
    private void Start()
    {
        _clickerHanlder.OnClick += CreateEffect;
    }
    
    private void CreateEffect()
    {
        Vector3 mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
        ParticleSystem particleSystem = Instantiate(_particleSystem, mousePosition, Quaternion.identity);
        Destroy(particleSystem.gameObject, _destroyTime);
    }

    private void OnDisable()
    {
        _clickerHanlder.OnClick += CreateEffect;
    }

}
