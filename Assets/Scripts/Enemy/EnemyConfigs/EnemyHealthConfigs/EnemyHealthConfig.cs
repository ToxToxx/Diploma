using UnityEngine;

[CreateAssetMenu(fileName = "EnemyHealthConfig", menuName = "Configs/EnemyConfig/EnemyHealthConfig")]
public class EnemyHealthConfig : ScriptableObject
{
    public Transform EnemyPrefab;
    public int MaxHealth;
    [field:Range (0,1)]  public float Armor;
}


