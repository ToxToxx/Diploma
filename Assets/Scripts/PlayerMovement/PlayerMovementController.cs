using UnityEngine;

using Zenject;
using System;
using UnityEngine.InputSystem;

public class PlayerMovementController : IDisposable
{

    private PlayerMovementModel _playerMovementModel;
    private PlayerInputAction _playerInputAction;

    [Inject]
    public void Construct(PlayerMovementModel playerMovementModel)
    {
        _playerMovementModel = playerMovementModel;
        _playerInputAction = new PlayerInputAction();
        _playerInputAction.Player.Move.performed += OnMovePerformed;
        _playerInputAction.Player.Enable();

    }
    public void Dispose()
    {
        _playerInputAction.Dispose();
    }

    private void OnMovePerformed(InputAction.CallbackContext context)
    {
        Debug.Log("я двигаюсь");
    }

    private Vector2 GetMovementVectorNormalized()
    {
        Vector2 inputVector = _playerInputAction.Player.Move.ReadValue<Vector2>();
        inputVector = inputVector.normalized;
        return inputVector;
    }

    public Vector3 GetMovementTransform()
    {
        float moveSpeed = _playerMovementModel.Speed;
        Vector2 inputVector = GetMovementVectorNormalized();

        Vector3 moveDir = new(inputVector.x, 0f, 0f);
        return moveDir * moveSpeed;
    }
}
