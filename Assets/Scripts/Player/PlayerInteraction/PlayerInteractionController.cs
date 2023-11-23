using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class PlayerInteractionController : MonoBehaviour, IDisposable
{
    [SerializeField] private Transform _interactorSource;
    [SerializeField] private float _interactRange;
    private PlayerInputSystem _playerInputSystem;
    [SerializeField] private LayerMask interactableLayer;

    [Inject]
    public void Construct(PlayerInputSystem playerInputSystem)
    {
        _playerInputSystem = playerInputSystem;
    }

    private void Awake()
    {
        _playerInputSystem.OnInteractPlayerInputPerformed += PlayerInputSystemInteractPerformed;
    }

    private void PlayerInputSystemInteractPerformed(InputAction.CallbackContext obj)
    {
        Debug.Log("Player Interacts");
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
        Ray2D ray = new Ray2D(transform.position, mousePosition - transform.position);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, _interactRange, interactableLayer);

        if (hit.collider != null)
        {
            Debug.Log("Hit object: " + hit.collider.gameObject.name);
            if (hit.collider.gameObject.TryGetComponent(out IInteractable interactObj))
            {
                interactObj.Interact();
            }
        }
    }

   public void Dispose()
    {
        _playerInputSystem.OnInteractPlayerInputPerformed -= PlayerInputSystemInteractPerformed;
    }
}
