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

    public Vector2 GetMovementVectorNormalized()
    {
        Vector2 inputVector = _playerInputAction.Player.Move.ReadValue<Vector2>();
        inputVector = inputVector.normalized;
        return inputVector;
    }

    public Vector3 GetMovementVectorMoveSpeed()
    {
        float moveSpeed = _playerMovementModel.Speed;
        Vector2 inputVector = GetMovementVectorNormalized();
        Vector3 moveDir = new(inputVector.x * moveSpeed, 0f, 0f);
        return moveDir;
    }

    public Vector3 GetMovementVectorJump()
    {
        float jumpForce = _playerMovementModel.JumpForce;
        Vector2 inputVector = GetMovementVectorNormalized();
        Vector3 jumpDIr = new(0f, inputVector.y * jumpForce, 0f);
        return jumpDIr;
    }
}
