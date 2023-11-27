using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;
using static UnityEngine.InputSystem.InputAction;

public class PlayerInputSystem: IDisposable
{
    private PlayerInputAction _playerInputAction;
    public event Action<InputAction.CallbackContext> OnJumpPlayerInputPerformed;
    public event Action<InputAction.CallbackContext> OnMovePlayerInputPerformed;

    public event Action<InputAction.CallbackContext> OnRunPlayerInputStarted;
    public event Action<InputAction.CallbackContext> OnRunPlayerInputCanceled;

    public event Action<InputAction.CallbackContext> OnInteractPlayerInputPerformed;

    public event Action<InputAction.CallbackContext> OnAttackPlayerInputPerformed;
    public event Action<InputAction.CallbackContext> OnAlternativeAttackPlayerInputPerformed;


    [Inject]
    public void Construct()
    {
        _playerInputAction = new PlayerInputAction();
        _playerInputAction.Player.Enable();

        _playerInputAction.Player.Move.performed += OnMovePerformed;
        _playerInputAction.Player.Jump.performed += OnJumpPerformed;
        _playerInputAction.Player.Interact.performed += OnInteractPerformed;

        _playerInputAction.Player.Run.started += OnRunStarted;
        _playerInputAction.Player.Run.canceled += OnRunCanceled;

        _playerInputAction.Player.Attack.performed += OnAttackPerformed;
        _playerInputAction.Player.AlternativeAttack.performed += OnAlternativeAttackPerformed;

    }

    private void OnAlternativeAttackPerformed(CallbackContext obj)
    {
        OnAlternativeAttackPlayerInputPerformed?.Invoke(obj);
    }

    private void OnAttackPerformed(CallbackContext obj)
    {
        OnAttackPlayerInputPerformed?.Invoke(obj);
    }

    private void OnRunStarted(CallbackContext obj)
    {
        OnRunPlayerInputStarted?.Invoke(obj);
    }
    private void OnRunCanceled(CallbackContext obj)
    {
        OnRunPlayerInputCanceled?.Invoke(obj);
    }

    private void OnInteractPerformed(CallbackContext obj)
    {
        OnInteractPlayerInputPerformed?.Invoke(obj);
    }

    private void OnJumpPerformed(CallbackContext obj)
    {
        OnJumpPlayerInputPerformed?.Invoke(obj);
    }

    private void OnMovePerformed(CallbackContext context)
    {
        OnMovePlayerInputPerformed?.Invoke(context);
    }

    public PlayerInputAction GetInputAction()
    {
        return _playerInputAction;
    }


    public void Dispose()
    {
        _playerInputAction.Player.Move.performed -= OnMovePerformed;
        _playerInputAction.Player.Jump.performed -= OnJumpPerformed;
        _playerInputAction.Player.Interact.performed -= OnInteractPerformed;
        _playerInputAction.Player.Run.started -= OnRunStarted;
        _playerInputAction.Player.Run.canceled -= OnRunCanceled;
        _playerInputAction.Player.Attack.performed -= OnAttackPerformed;
        _playerInputAction.Player.AlternativeAttack.performed -= OnAlternativeAttackPerformed;
        _playerInputAction.Dispose();
    }
}
