using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryCellUI : MonoBehaviour
{
    [SerializeField] private Image _itemImage;
    [SerializeField] private TextMeshProUGUI _itemCountText;
    [SerializeField] private Sprite _defaultImage;


    public void SetItem(IInventoryItem inventoryItem)
    {
        if (inventoryItem != null)
        {
            _itemImage.sprite = inventoryItem.Sprite;
            _itemCountText.text = inventoryItem.ItemCount.ToString();
        }
        else
        {
            _itemImage.sprite = _defaultImage;
            _itemCountText.text = "0";
        }
    }
}
