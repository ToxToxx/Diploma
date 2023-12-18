using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static InventoryItemType;

[CreateAssetMenu(fileName = "HealthKitConfig", menuName = "Configs/InventoryItem/HealthKit")]
public class HealthKitConfig : ScriptableObject
{
    public string Name;
    public string Description;
    public Sprite Sprite;
    public ItemType Type;
    public int ItemCount;
    public int HealingCount;
}
