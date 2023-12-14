using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayersInventoryCellsViewUI : MonoBehaviour
{
    private PlayerInventoryController _playerInventoryController;
    [SerializeField] private GameObject _inventoryCellPrefab;
    [SerializeField] private Transform _cellContainer;

    [Inject]
    public void Construct(PlayerInventoryController playerInventoryController)
    {
        _playerInventoryController = playerInventoryController;
        UpdateInventoryView();
    }

    private void UpdateInventoryView()
    { 
        // Clear existing cells
        foreach (Transform child in _cellContainer)
        {
            Destroy(child.gameObject);
        }

        // Create cells for each item in the player's inventory
        foreach (GameObject playerInventoryItem in _playerInventoryController.GetPlayerInventory())
        {
            GameObject cell = Instantiate(_inventoryCellPrefab, _cellContainer);
            InventoryCellUI cellUI = cell.GetComponent<InventoryCellUI>();

            // Set sprite and item count in the cell
            cellUI.SetItem(playerInventoryItem.GetComponent<IInventoryItem>());
        }
    }
}
