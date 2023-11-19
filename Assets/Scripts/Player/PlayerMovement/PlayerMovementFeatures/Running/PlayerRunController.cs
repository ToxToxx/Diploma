using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class PlayerRunController : MonoBehaviour,IDisposable
{
    private PlayerRunModel _playerRunModel;
    private PlayerMovementModel _playerMovementModel;
    private PlayerInputAction _playerInputAction;


    private Coroutine _staminaRegenerationCoroutine;
    public event Action<float> OnPlayerRun;

    private bool _isRunning = false;
    private float _staminaRegenerationCooldown = 1.0f;

    [Inject]
    public void Construct(PlayerMovementModel playerMovementModel, PlayerRunModel playerRunModel)
    {
        _playerMovementModel = playerMovementModel;
        _playerRunModel = playerRunModel;
        _playerInputAction = new PlayerInputAction();
        _playerInputAction.Player.Enable();

        _playerInputAction.Player.Run.started += OnRunStarted;
        _playerInputAction.Player.Run.canceled += OnRunCanceled;

        _staminaRegenerationCoroutine = StartCoroutine(RegenerateStamina());
    }

    public void Dispose()
    {
        _playerInputAction.Player.Run.started -= OnRunStarted;
        _playerInputAction.Player.Run.canceled -= OnRunCanceled;
        _playerInputAction.Dispose();

        if (_staminaRegenerationCoroutine != null)
        {
            StopCoroutine(_staminaRegenerationCoroutine);
        }
    }

    private void OnRunStarted(InputAction.CallbackContext obj)
    {
        if (_playerRunModel.CurrentStamina > 0)
        {
            _isRunning = true;
            UpdatePlayerSpeed();
        }
    }

    private void OnRunCanceled(InputAction.CallbackContext obj)
    {
        _isRunning = false;
        UpdatePlayerSpeed();
    }

    private void UpdatePlayerSpeed()
    {
        _playerMovementModel.Speed = _isRunning ? _playerRunModel.SpeedCoef : 1.0f;
    }

    private IEnumerator RegenerateStamina()
    {
        while (true)
        {
            yield return new WaitForSeconds(_staminaRegenerationCooldown);

            if (!_isRunning && _playerRunModel.CurrentStamina < _playerRunModel.MaxStamina)
            {
                _playerRunModel.CurrentStamina += _playerRunModel.StaminaRegenerationRate;
                _playerRunModel.CurrentStamina = Mathf.Clamp(_playerRunModel.CurrentStamina, 0, _playerRunModel.MaxStamina);
            }
        }
    }
}
