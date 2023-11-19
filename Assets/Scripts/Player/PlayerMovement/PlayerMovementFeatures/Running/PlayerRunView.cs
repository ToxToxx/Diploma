using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class PlayerRunView : MonoBehaviour, IDisposable
{
    private PlayerRunController _runController;

    [SerializeField] private Image _staminaBarImage;

    private float _maxStamina;
    private float _currentStamina = 100;

    [Inject]
    public void Construct(PlayerRunController controller)
    {
        _runController = controller;
        _runController.OnPlayerRun += UpdateAnimationState;
    }

    private void Awake()
    {
        _maxStamina = _runController.GetMaxStamina();
    }

    private void Update()
    {
        UpdateStaminaState();
    }

    private void UpdateAnimationState(bool isRunning) { }
    private void UpdateStaminaState()
    {
        _currentStamina = _runController.GetCurrentStamina();
        float fillAmount = _currentStamina / _maxStamina;
        _staminaBarImage.fillAmount = fillAmount;     
    }

    public void Dispose()
    {
       _runController.OnPlayerRun -= UpdateAnimationState;
    }
}
