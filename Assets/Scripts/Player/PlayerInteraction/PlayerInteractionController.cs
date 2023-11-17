using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractionController : MonoBehaviour
{
    [SerializeField] private Transform _interactorSource;
    [SerializeField] private float _interactRange;
    private PlayerInputAction _playerInputAction;
    [SerializeField] private LayerMask interactableLayer;

    private void Awake()
    {
        _playerInputAction = new PlayerInputAction();
        _playerInputAction.Player.Interact.performed += OnInteractPerformed;
        _playerInputAction.Player.Enable();
    }
    private void OnInteractPerformed(InputAction.CallbackContext obj)
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

}
