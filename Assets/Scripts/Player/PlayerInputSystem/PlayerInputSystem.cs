using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class PlayerInputSystem: IDisposable
{
    private PlayerInputAction _playerInputAction;
    public event Action<InputAction.CallbackContext> OnJumpPlayerInputPerformed;
    public event Action<InputAction.CallbackContext> OnMovePlayerInputPerformed;

    public event Action<InputAction.CallbackContext> OnRunPlayerInputStarted;
    public event Action<InputAction.CallbackContext> OnRunPlayerInputCanceled;

    public event Action<InputAction.CallbackContext> OnInteractPlayerInputPerformed;

    public event Action<InputAction.CallbackContext> OnAttackPlayerInputPerformed;
    public event Action<InputAction.CallbackContext> OnAttackPlayerInputStarted;
    public event Action<InputAction.CallbackContext> OnAttackPlayerInputCanceled;

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
        _playerInputAction.Player.MeleeWeapon.performed += OnMeleeWeaponAttackPerformed;
        _playerInputAction.Player.MeleeWeapon.started += OnMeleeWeaponAttackStarted;
        _playerInputAction.Player.MeleeWeapon.canceled += OnMeleeWeaponAttackCanceled;
    }

    private void OnMeleeWeaponAttackCanceled(InputAction.CallbackContext obj)
    {
        OnAttackPlayerInputCanceled?.Invoke(obj);
    }

    private void OnMeleeWeaponAttackStarted(InputAction.CallbackContext obj)
    {
        OnAttackPlayerInputStarted?.Invoke(obj);
    }

    private void OnMeleeWeaponAttackPerformed(InputAction.CallbackContext obj)
    {
        OnAttackPlayerInputPerformed?.Invoke(obj);
    }

    private void OnRunStarted(InputAction.CallbackContext obj)
    {
        OnRunPlayerInputStarted?.Invoke(obj);
    }
    private void OnRunCanceled(InputAction.CallbackContext obj)
    {
        OnRunPlayerInputCanceled?.Invoke(obj);
    }

    private void OnInteractPerformed(InputAction.CallbackContext obj)
    {
        OnInteractPlayerInputPerformed?.Invoke(obj);
    }

    private void OnJumpPerformed(InputAction.CallbackContext obj)
    {
        OnJumpPlayerInputPerformed?.Invoke(obj);
    }

    private void OnMovePerformed(InputAction.CallbackContext context)
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
        _playerInputAction.Player.MeleeWeapon.performed -= OnMeleeWeaponAttackPerformed;
        _playerInputAction.Dispose();
    }
}
