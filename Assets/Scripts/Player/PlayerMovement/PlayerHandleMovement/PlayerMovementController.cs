using UnityEngine;
using Zenject;
using System;
using UnityEngine.InputSystem;

public class PlayerMovementController : IDisposable
{

    private PlayerMovementModel _playerMovementModel;
    private PlayerInputAction _playerInputAction;
    public event EventHandler OnPlayersJump;

    [Inject]
    public void Construct(PlayerMovementModel playerMovementModel)
    {
        _playerMovementModel = playerMovementModel;
        _playerInputAction = new PlayerInputAction();
        _playerInputAction.Player.Move.performed += OnMovePerformed;
        _playerInputAction.Player.Jump.performed += OnJumpPerformed;
        _playerInputAction.Player.Enable();

    }

    private void OnJumpPerformed(InputAction.CallbackContext obj)
    {
        OnPlayersJump?.Invoke(this, EventArgs.Empty);
    }

    public void Dispose()
    {
        _playerInputAction.Player.Move.performed -= OnMovePerformed;
        _playerInputAction.Player.Jump.performed -= OnJumpPerformed;
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
        Vector3 moveDir = new(inputVector.x * moveSpeed, inputVector.y, 0f);
        return moveDir;
    }
    
    public float GetJumpForce()
    {
        return _playerMovementModel.JumpForce;
    }
}
