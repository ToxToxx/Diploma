using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputSystem: IInitializable
{
    private PlayerInputAction _playerInputAction;
    public event Action<InputAction.CallbackContext> OnJumpPlayerInputPerformed;
    public event Action<InputAction.CallbackContext> OnMovePlayerInputPerformed;



    public void Initialize()
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
        Debug.Log("я двигаюсь");
    }
}
