using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class PlayerStaminaAndRunController : MonoBehaviour, IDisposable, ITickable
{
    [SerializeField] private LayerMask _enemyLayerMask;
    private PlayerRunModel _playerRunModel;
    private PlayerMovementModel _playerMovementModel;
    private PlayerInputSystem _playerInputSystem;

    public event Action<bool> OnPlayerRun;

    private bool _isRunning = false;
    private float _staminaRegenerationCooldown = 1.0f;
    private float _decreaseStaminaRate = 50f;

    private float _initialSpeed;

    [Inject]
    public void Construct(PlayerMovementModel playerMovementModel, PlayerRunModel playerRunModel, PlayerInputSystem playerInputSystem)
    {
        _playerMovementModel = playerMovementModel;
        _playerRunModel = playerRunModel;
        _playerInputSystem = playerInputSystem;

        _playerInputSystem.OnRunPlayerInputStarted += OnRunStarted;
        _playerInputSystem.OnRunPlayerInputCanceled += OnRunCanceled;

        _initialSpeed = _playerMovementModel.Speed;
        StartCoroutine(RegenerateStamina());
    }
  
    public void Tick()
    {
        DecreaseStamina();
    }
    public void Dispose()
    {
        _playerInputSystem.OnRunPlayerInputStarted -= OnRunStarted;
        _playerInputSystem.OnRunPlayerInputCanceled -= OnRunStarted;
    }

    private void OnRunStarted(InputAction.CallbackContext obj)
    {
        if (_playerRunModel.CurrentStamina > 0)
        {
            _isRunning = true;

            SetCollisionWithEnemies(!_isRunning);

            UpdatePlayerSpeed();
            OnPlayerRun?.Invoke(_isRunning);
        }
    }

    private void OnRunCanceled(InputAction.CallbackContext obj)
    {
        _isRunning = false;
        UpdatePlayerSpeed();
        SetCollisionWithEnemies(!_isRunning);
    }

    private void SetCollisionWithEnemies(bool enableCollision)
    {
        if (_isRunning)
        {
            // Get all colliders of type Enemy using the provided enemyLayerMask
            Collider2D[] enemyColliders = Physics2D.OverlapCircleAll(transform.position, 1f, _enemyLayerMask);

            // Enable or disable collision based on the parameter
            foreach (Collider2D enemyCollider in enemyColliders)
            {
                // Check if either collider is a trigger
                bool isTriggerCollision = GetComponent<Collider2D>().isTrigger || enemyCollider.isTrigger;

                // Ignore collision only if both colliders are triggers
                if (!isTriggerCollision)
                {
                    Physics2D.IgnoreCollision(GetComponent<Collider2D>(), enemyCollider, !enableCollision);
                }
            }

            Debug.Log($"Collision with enemies set to: {enableCollision}");
        }
    }

    private void UpdatePlayerSpeed()
    {
        _playerMovementModel.Speed = _isRunning ? _initialSpeed * _playerRunModel.SpeedCoef : _initialSpeed;
    }

    private void DecreaseStamina()
    {
        if (_isRunning)
        {
            if (_playerRunModel.CurrentStamina <= 0)
            {
                _isRunning = false;
                _playerMovementModel.Speed = _initialSpeed;
            }
            _playerRunModel.CurrentStamina -= _decreaseStaminaRate * Time.deltaTime;
        }
    }
    public void DecreaseStaminaOnAmount(float amount)
    {
        _playerRunModel.CurrentStamina -= amount;
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

    public void SetCurrentStamina(float amount)
    {
        _playerRunModel.CurrentStamina = amount;
    }
    public float GetMaxStamina()
    {
        return _playerRunModel.MaxStamina;
    }
    public float GetCurrentStamina()
    {
        return _playerRunModel.CurrentStamina;
    }
}
