using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayersInventoryCellsViewUI : MonoBehaviour
{
    private PlayerInventoryController _playerInventoryController;
    [SerializeField] private GameObject _inventoryCellPrefab;
    [SerializeField] private Transform _cellContainer;
    private int _requiredCellCount;
    private int _cellCounter = 0;

    [Inject]
    public void Construct(PlayerInventoryController playerInventoryController)
    {
        _playerInventoryController = playerInventoryController;
    }

    private void Update()
    {
        _requiredCellCount = _playerInventoryController.GetPlayerInventoryCount();
        UpdateInventoryView();
    }
    private void UpdateInventoryView()
    {
        if(_cellCounter < _requiredCellCount)
        {
            for (int i = 0; i < _requiredCellCount; i++)
            {
                Instantiate(_inventoryCellPrefab, _cellContainer);
                _cellCounter++;
            }
        }
        for (int i = 0; i < _playerInventoryController.GetPlayerInventory().Count; i++)
        {
            GameObject cell = _cellContainer.GetChild(i).gameObject;
            InventoryCellUI cellUI = cell.GetComponent<InventoryCellUI>();

            GameObject playerInventoryItem = _playerInventoryController.GetPlayerInventory()[i];
            cellUI.SetItem(playerInventoryItem.GetComponent<IInventoryItem>());
        }

    }
}
