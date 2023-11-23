using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static InteractableObjectsConfig;
using static MeleeWeaponConfig;

public class MeleeWeaponTypeController
{
    public MeleeWeaponTypeController () { }

    public IMeleeWeapon InitializeMeleeWeaponType(MeleeWeaponConfig meleeWeaponConfig)
    {
        MeleeWeaponType currentType = meleeWeaponConfig.Type;
        switch (currentType)
        {
            case (MeleeWeaponType.Default):
                return new MeleeWeaponModel(meleeWeaponConfig);
            default:
                return new MeleeWeaponModel(meleeWeaponConfig);
        }
    } 
    
}
