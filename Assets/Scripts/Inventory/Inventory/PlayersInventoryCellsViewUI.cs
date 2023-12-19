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
        _playerInventoryController.OnUpdateInventoryCount += OnUpdateInventoryCount;
    }

    private void OnUpdateInventoryCount(object sender, System.EventArgs e)
    {
        _requiredCellCount = _playerInventoryController.GetPlayerInventoryCount();
        CreateInventory();
    }
    private void Start()
    {
        _requiredCellCount = _playerInventoryController.GetPlayerInventoryCount();
        CreateInventory();
    }

    private void Update()
    {
        UpdateInventoryView();
    }
    private void UpdateInventoryView()
    {
        int inventoryItemCount = _playerInventoryController.GetPlayerInventory().Count;

        if (_cellCounter != _requiredCellCount)
        {
            CreateInventory();
            return; 
        }

        for (int i = 0; i < _cellCounter; i++)
        {
            GameObject cell = _cellContainer.GetChild(i).gameObject;
            InventoryCellUI cellUI = cell.GetComponent<InventoryCellUI>();

            if (i < inventoryItemCount)
            {
                GameObject playerInventoryItem = _playerInventoryController.GetPlayerInventory()[i];
                if (playerInventoryItem != null)
                {
                    IInventoryItem inventoryItem = playerInventoryItem.GetComponent<IInventoryItem>();
                    if (inventoryItem != null)
                    {
                        cellUI.SetItem(inventoryItem);
                    }
                }
            }
            else
            {
                cellUI.SetItem(null);
            }
        }
    }

    private void CreateInventory()
    {
        if (_cellCounter < _requiredCellCount)
        {
            for (int i = 0; i < _requiredCellCount; i++)
            {
                _ = Instantiate(_inventoryCellPrefab, _cellContainer);
                _cellCounter++;
            }
        }
    }
}
