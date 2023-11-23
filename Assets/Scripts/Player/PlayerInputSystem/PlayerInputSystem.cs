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
    [Inject]
    public void Construct(PlayerMovementModel playerMovementModel, PlayerInputSystem playerInputSystem)
    {
        _playerInputAction = new PlayerInputAction();
        _playerInputAction.Player.Enable();
        _playerInputAction.Player.Move.performed += OnMovePerformed;
        _playerInputAction.Player.Jump.performed += OnJumpPerformed;

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
        _playerInputAction.Dispose();
    }
}
