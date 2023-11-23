using UnityEngine;
using Zenject;
using System;
using UnityEngine.InputSystem;

public class PlayerMovementController : IDisposable
{

    private PlayerMovementModel _playerMovementModel;
    public event EventHandler OnPlayersJump;
    private PlayerInputSystem _playerInputSystem;

    [Inject]
    public void Construct(PlayerMovementModel playerMovementModel, PlayerInputSystem playerInputSystem)
    {
        _playerMovementModel = playerMovementModel;
        _playerInputSystem = playerInputSystem;
        _playerInputSystem.OnJumpPlayerInputPerformed += OnPlayerInputJump;
        _playerInputSystem.OnMovePlayerInputPerformed += OnPlayerInputMove;
    }

    private void OnPlayerInputJump(InputAction.CallbackContext obj)
    {
        OnPlayersJump?.Invoke(this, EventArgs.Empty);
    }

    public void Dispose()
    {
        _playerInputSystem.OnJumpPlayerInputPerformed -= OnPlayerInputJump;
        _playerInputSystem.OnMovePlayerInputPerformed -= OnPlayerInputMove;
    }

    private void OnPlayerInputMove(InputAction.CallbackContext context)
    {
        Debug.Log("я двигаюсь");
    }

    public Vector2 GetMovementVectorNormalized()
    {
        Vector2 inputVector = _playerInputSystem.GetInputAction().Player.Move.ReadValue<Vector2>();
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
