using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinHanlder : MonoBehaviour
{
    [SerializeField] private GameObject _winEffect;
    [SerializeField] private float _disapperedTime = 2;

    public void Win()
    {
        StartCoroutine(CoolDown());
    }

    private IEnumerator CoolDown()
    {
        _winEffect.SetActive(true);
        yield return new WaitForSeconds(_disapperedTime);
        _winEffect.SetActive(false);
    }
}
