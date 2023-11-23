using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IMeleeWeapon
{
    public string Name { get; set; }
    public float AttackDamage { get; set; }
    public float AttackSpeed { get; set; }
    public float AttackDistance { get; set; }
    public Sprite WeaponImage { get; set; }
    public Sprite WeaponSprite { get; set; }
    public string WeaponDescription { get; set; }
}
