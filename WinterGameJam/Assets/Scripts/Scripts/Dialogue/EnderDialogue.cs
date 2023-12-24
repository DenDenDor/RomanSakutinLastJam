using Fungus;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnderDialogue : MonoBehaviour
{
    [SerializeField] private Flowchart _startFlowchart;

    [SerializeField] private float _waitTime;
    private bool _isWorking = false;

    public event Action OnDialogueEnd;

    private void Start()
    {
        StartCoroutine(CoolDown());
    }

    private void Update()
    {
        if (_isWorking)
        {
            if (_startFlowchart.SelectedBlock.IsExecuting() == false)
            {
                OnDialogueEnd?.Invoke();
                _isWorking = false;
            }
        }
    }

    private IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(_waitTime);
        _isWorking = true;
    }
}
