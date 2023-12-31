using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeaponModel : IMeleeWeapon
{
    public string Name { get; set; }
    public float AttackDamage { get; set; }
    public float AlternativeAttackCritDamage { get; set; }
    public float AttackSpeed { get; set; }
    public float AttackDistance { get; set; }
    public float AlternativeAttackStaminaCost { get; set; }
    public Sprite WeaponImage { get; set; }
    public Sprite WeaponSprite { get; set; }
    public string WeaponDescription { get; set; }

    public MeleeWeaponModel (MeleeWeaponConfig meleeWeaponConfig)
    {
        Name = meleeWeaponConfig.Name;

        AttackDamage = meleeWeaponConfig.AttackDamage;
        AlternativeAttackCritDamage = meleeWeaponConfig.AlternativeAttackCritDamage;
        AttackSpeed = meleeWeaponConfig.AttackSpeed;
        AttackDistance = meleeWeaponConfig.AttackDistance;
        AlternativeAttackStaminaCost = meleeWeaponConfig.AlternativeAttackStaminaCost; 

        WeaponImage = meleeWeaponConfig.MeleeWeaponIcon;
        WeaponSprite = meleeWeaponConfig.MeleeWeaponSprite;
        WeaponDescription = meleeWeaponConfig.WeaponDescription;
    }
}
