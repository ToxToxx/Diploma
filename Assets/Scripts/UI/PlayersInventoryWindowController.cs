using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayersInventoryWindowController : MonoBehaviour
{
    private PlayerInputSystem _playerInputSystem;
    private bool _isInventoryOpen;
    [SerializeField] private GameObject _playerInventoryWindow;

    [Inject]
    public void Construct(PlayerInputSystem playerInputSystem)
    {
        _playerInputSystem = playerInputSystem;
        _playerInputSystem.OnInventoryWindowOpenPerformed += PlayerInputSystemOnInventoryOpenPerformed;
        Hide();
    }

    private void PlayerInputSystemOnInventoryOpenPerformed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if(_isInventoryOpen)
        {
            Hide();
        }
        else
        {
            Show();
        }
    }


    public void Show()
    {
        _playerInventoryWindow.SetActive(true);
        _isInventoryOpen = true;
    }

    public void Hide()
    {
        _playerInventoryWindow.SetActive(false);
        _isInventoryOpen = false;
    }
}
