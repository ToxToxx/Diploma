using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XInput;
using UnityEngine.InputSystem;
using Zenject;
using System;

public class PlayerMovementController : IInitializable, IDisposable
{

    private PlayerMovementModel _playerMovementModel;
    private PlayerInputAction _playerInputAction;
    public event Action<Vector2, float> OnMove;

    [Inject]
    public void Construct(PlayerMovementModel playerMovementModel)
    {

        _playerMovementModel = playerMovementModel;
        _playerInputAction = new PlayerInputAction();

    }

    public void Initialize()
    {
        _playerInputAction.Player.Move.performed += OnMovePerformed;
    }
    public void Dispose()
    {
        _playerInputAction.Player.Move.performed -= OnMovePerformed;
    }


    private void OnMovePerformed(InputAction.CallbackContext context)
    {
        Vector2 moveInput = context.ReadValue<Vector2>();
        OnMove?.Invoke(moveInput, _playerMovementModel.Speed);
    }

    public void SetMoveSpeed(float speed)
    {
        _playerMovementModel.Speed = speed;
    }
}
