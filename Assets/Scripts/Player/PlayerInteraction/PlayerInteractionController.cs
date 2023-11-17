using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractionController : MonoBehaviour
{
    [SerializeField] private Transform _interactorSource;
    [SerializeField] private float _interactRange;
    private PlayerInputAction _playerInputAction;


    private void Awake()
    {
        _playerInputAction = new PlayerInputAction();
        _playerInputAction.Player.Interact.performed += OnInteractPerformed;
        _playerInputAction.Player.Enable();
    }

    private void OnInteractPerformed(InputAction.CallbackContext obj)
    {
        Ray ray = new Ray(_interactorSource.position, _interactorSource.forward);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, _interactRange))
        {
            if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
            {
                interactObj.Interact();
            }
        }
    }
}
