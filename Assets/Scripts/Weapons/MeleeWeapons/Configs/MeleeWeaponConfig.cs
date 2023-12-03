using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MeleeWeaponConfig", menuName = "Configs/WeaponConfig/MeleeWeaponConfig")]
public class MeleeWeaponConfig : ScriptableObject
{
    public string Name;

    public float AttackDamage;
    public float AttackSpeed;
    public float AttackDistance;
    public float AlternativeAttackCritDamage;
    public float AlternativeAttackStaminaCost;

    public Sprite MeleeWeaponIcon;
    public Sprite MeleeWeaponSprite;

    public string WeaponDescription;

    public  MeleeWeaponType Type;
    public enum MeleeWeaponType
    {
        Default,

    }
}
