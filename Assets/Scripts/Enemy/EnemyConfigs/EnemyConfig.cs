using UnityEngine;

[CreateAssetMenu(fileName = "EnemyConfig", menuName = "Configs/EnemyConfig")]
public class EnemyConfig : ScriptableObject
{
    public Transform EnemyPrefab;
    public int MaxHealth;
    [field:Range (0,1)]  public float Armor;
}


