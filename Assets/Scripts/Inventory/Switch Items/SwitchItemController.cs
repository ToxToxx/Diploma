using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SwitchItemController : MonoBehaviour
{
    [SerializeField] private GameObject[] _weaponControllers;
    [SerializeField] private GameObject _menuWindow;
    private CurrentItemStateModel _currentItemStateModel;
    private PlayerInputSystem _playerInputSystem;

    [Inject]
    public void Construct(PlayerInputSystem playerInputSystem)
    {
        _currentItemStateModel = new CurrentItemStateModel();
        _playerInputSystem = playerInputSystem;
        _playerInputSystem.OnSwitchItemPerformed += PlayerInputOnSwitchItemPerformed;
        _playerInputSystem.OnInventoryWindowOpenPerformed += OnInventoryWindowOpened;
        _currentItemStateModel.CurrentItemType = CurrentItemStateModel.CurrentItemState.Primary;
    }

    private void OnInventoryWindowOpened(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (!_menuWindow.activeInHierarchy)
        {   
            _currentItemStateModel.CurrentItemType = CurrentItemStateModel.CurrentItemState.Inventory;
        } else
        {
            _currentItemStateModel.CurrentItemType = CurrentItemStateModel.CurrentItemState.Primary;
        } 
    }

    private void PlayerInputOnSwitchItemPerformed(int obj)
    {
        switch (obj)
        {
            case 1:
                _currentItemStateModel.CurrentItemType = CurrentItemStateModel.CurrentItemState.Primary;
                break;
            case 2:
                _currentItemStateModel.CurrentItemType = CurrentItemStateModel.CurrentItemState.Secondary;
                break;
            case 3:
                _currentItemStateModel.CurrentItemType = CurrentItemStateModel.CurrentItemState.UsableItem;
                break;
            case 4:
                _currentItemStateModel.CurrentItemType = CurrentItemStateModel.CurrentItemState.NoHands;
                break;
        }
    }

    public CurrentItemStateModel.CurrentItemState GetCurrentItemState()
    {
        return _currentItemStateModel.CurrentItemType;
    }
}
