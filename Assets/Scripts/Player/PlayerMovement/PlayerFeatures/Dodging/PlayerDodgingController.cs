using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerDodgingController : MonoBehaviour
{
    [SerializeField] private float _teleportDistance = 5f;
    [SerializeField] private float _staminaDecreaseAmount = 20f;
    [SerializeField] private Transform _playerTransform;
 
    private PlayerStaminaAndRunController _playerStaminaAndRunController;
    private PlayerInputSystem _playerInputSystem;

    [Inject]
    public void Construct(PlayerStaminaAndRunController playerStaminaAndRunController, PlayerInputSystem playerInputSystem)
    {
        _playerStaminaAndRunController = playerStaminaAndRunController;
        _playerInputSystem = playerInputSystem;
        _playerInputSystem.OnDodgePlayerInputPerformed += OnDodgePlayerInputSystemPerformed;
    }

    private void OnDodgePlayerInputSystemPerformed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        PerformDodging();
        _playerStaminaAndRunController.DecreaseStaminaOnAmount(_staminaDecreaseAmount);
    }

    private void PerformDodging()
    {
        Vector3 currentPosition = transform.position;

        Vector3 teleportPosition = new(currentPosition.x + (_teleportDistance * _playerTransform.localScale.x), currentPosition.y, currentPosition.z);

        transform.position = teleportPosition;
    }
}
