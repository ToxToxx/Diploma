using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryCellUI : MonoBehaviour
{
    [SerializeField] private Image _itemImage;
    [SerializeField] private TextMeshProUGUI _itemCountText;

    public void SetItem(IInventoryItem inventoryItem)
    {
        _itemImage.sprite = inventoryItem.Sprite;
        _itemCountText.text = inventoryItem.ItemCount.ToString();
    }
}
