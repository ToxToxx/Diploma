using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "EnemyConfig", menuName = "Configs/EnemyConfig")]
public class EnemyConfig : ScriptableObject
{
    public Transform EnemyPrefab;
    public int MaxHealth;
    public TypeHealthModel HealthModelType;
    public enum TypeHealthModel
    {
        Default,
    }

}
