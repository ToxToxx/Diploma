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
        //_runController.OnPlayerRun += UpdateStaminaState;
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
/*
    private void UpdateStaminaState(float currentStamina)
    {
        _currentStamina = currentStamina;
        _staminaText.text = "" + _runController.GetCurrentStamina();
        float fillAmount = currentStamina / _maxStamina;
        _staminaBarImage.fillAmount = fillAmount;
    }
*/
    private void UpdateStaminaState()
    {
        _currentStamina = _runController.GetCurrentStamina();
        _staminaText.text = "" + _currentStamina;
        float fillAmount = _currentStamina / _maxStamina;
        _staminaBarImage.fillAmount = fillAmount;
        Debug.Log(_currentStamina);
        /*
        if (Input.GetKeyDown(KeyCode.I))
        {
            
            _currentStamina -= 10;
        }*/
    }
    public void Dispose()
    {
       //runController.OnPlayerRun -= UpdateStaminaState;
    }
}
