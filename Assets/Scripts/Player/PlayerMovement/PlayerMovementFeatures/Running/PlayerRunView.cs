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
    [SerializeField] private TextMeshProUGUI _staminaText;

    private float _maxStamina;
    private float _currentStamina = 100;

    [Inject]
    public void Construct(PlayerRunController controller)
    {
        _runController = controller;
        _runController.OnPlayerRun += UpdateAnimationState;
        _staminaText.text = "100";
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
        ChangeStaminaText();
        float fillAmount = _currentStamina / _maxStamina;
        _staminaBarImage.fillAmount = fillAmount;     
    }

    private void ChangeStaminaText()
    {
        if(_currentStamina < 0)
        {
            _currentStamina = 0;     
        }
        _staminaText.text = "" + _currentStamina;
    }
    public void Dispose()
    {
       _runController.OnPlayerRun -= UpdateAnimationState;
    }
}
