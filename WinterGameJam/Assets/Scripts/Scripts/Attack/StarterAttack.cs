using Fungus;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarterAttack : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private Camera _battleCamera;
    public BlockReference blockRef;
    [SerializeField] private float _waitTime = 1;
    [SerializeField] private EnderDialogue _enderDialogue;
    [SerializeField] private GameObject _battle;
    [SerializeField] private GameObject _dialogue;
    [SerializeField] private ClickerHanlder _clickerHanlder;

    private void Awake()
    {
        _enderDialogue.OnDialogueEnd += TurnOffDialogue;
        _clickerHanlder.OnBattleOver += TurnOnDialogue;
    }
    private void TurnOnDialogue()
    {
        ChangeActive(false);
        blockRef.Execute();
    }

    private void TurnOffDialogue()
    {
        ChangeActive(true);
    }

    private void ChangeActive(bool isTurnOn)
    {
        _dialogue.SetActive(!isTurnOn);
        _battleCamera.gameObject.SetActive(isTurnOn);
        _mainCamera.gameObject.SetActive(!isTurnOn);
        StartCoroutine(CoolDown(isTurnOn));
    }

    private IEnumerator CoolDown(bool isTurnOn)
    {
        yield return new WaitForSeconds(_waitTime);
        _battle.SetActive(isTurnOn);
    }

    private void OnDisable()
    {
        _enderDialogue.OnDialogueEnd -= TurnOffDialogue;
        _clickerHanlder.OnBattleOver -= TurnOnDialogue;
    }
}
