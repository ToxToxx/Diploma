using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SwitchItemController : MonoBehaviour
{
    [SerializeField] private GameObject[] _weaponControllers; 
    private CurrentItemStateModel _currentItemStateModel;
    private PlayerInputSystem _playerInputSystem;

    [Inject]
    public void Construct(PlayerInputSystem playerInputSystem)
    {
        _currentItemStateModel = new CurrentItemStateModel();
        _playerInputSystem = playerInputSystem;
        _playerInputSystem.OnSwitchItemPerformed += PlayerInputOnSwitchItemPerformed;
        _currentItemStateModel.CurrentItemType = CurrentItemStateModel.CurrentItemState.Primary;
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
                _currentItemStateModel.CurrentItemType = CurrentItemStateModel.CurrentItemState.FirstUsableItem;
                break;
            case 4:
                _currentItemStateModel.CurrentItemType = CurrentItemStateModel.CurrentItemState.SecondaryUsableItem;
                break;
            case 5:
                _currentItemStateModel.CurrentItemType = CurrentItemStateModel.CurrentItemState.ThirdUsableItem;
                break;
        }
    }

    public CurrentItemStateModel.CurrentItemState GetCurrentItemState()
    {
        return _currentItemStateModel.CurrentItemType;
    }
}
