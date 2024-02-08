using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static InventoryItemType;

[CreateAssetMenu(fileName = "AmmoConfig", menuName = "Configs/InventoryItem/AmmoConfig")]
public class AmmoConfig : ScriptableObject
{
    public string Name;
    public string Description;
    public Sprite Sprite;
    public ItemType Type;
    public int ItemCount;
    private void OnEnable()
    {
        ItemCount = Random.Range(3, 7);
    }
}
