using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class UsableItemController : MonoBehaviour, IWeaponController
{
    [SerializeField] private GameObject _inventoryItem;
    [SerializeField] private CurrentItemStateModel.CurrentItemState _currentItemState;
    private SwitchItemController _switchItemController;
    private PlayerInputSystem _playerInputSystem;
    private bool canAttack = true;

    [Inject]
    public void Construct(PlayerInputSystem playerInputSystem, SwitchItemController switchItemController)
    {
        _playerInputSystem = playerInputSystem;
        _switchItemController = switchItemController;
        _playerInputSystem.OnAttackPlayerInputPerformed += OnItemAttackPerformed;
        _playerInputSystem.OnAlternativeAttackPlayerInputPerformed += OnAlternativeItemAttackPerformed;
    }

    private void OnAlternativeItemAttackPerformed(InputAction.CallbackContext obj)
    {
        if (canAttack && _switchItemController.GetCurrentItemState() == _currentItemState)
        {
            PerformAlternativeAttack();
        }
    }

    private void OnItemAttackPerformed(InputAction.CallbackContext obj)
    {
        if (canAttack && _switchItemController.GetCurrentItemState() == _currentItemState)
        {
            PerformAttack();
        }
    }
    public void PerformAttack()
    {
        if (_inventoryItem != null)
        {
            _inventoryItem.GetComponent<IInventoryItem>().UseInventoryItem();
        }
    }


    public void PerformAlternativeAttack()
    {
        Debug.Log("Alternative Attack");
    }

    public void Dispose()
    {
        _playerInputSystem.OnAttackPlayerInputPerformed -= OnItemAttackPerformed;
    }
}

