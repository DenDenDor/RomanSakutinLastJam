using Fungus;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarterAttack : MonoBehaviour
{
    [SerializeField] private EnderDialogue _enderDialogue;
    [SerializeField] private GameObject _battle;
    [SerializeField] private GameObject _dialogue;

    private void Awake()
    {
        _enderDialogue.OnDialogueEnd += TurnOffDialogue;
    }

    private void TurnOffDialogue()
    {
        _battle.SetActive(true);
        _dialogue.SetActive(false);
    }

    private void OnDisable()
    {
        _enderDialogue.OnDialogueEnd -= TurnOffDialogue;
    }
}
