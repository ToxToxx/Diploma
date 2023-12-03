using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeaponVisualView : MonoBehaviour
{
    [SerializeField] private MeleeWeaponController _meleeWeaponController;
    [SerializeField] private MeleeWeaponVisualView _meleeWeaponVisualView;

    private SpriteRenderer _spriteRenderer;
    private void Awake()
    {
        _spriteRenderer = _meleeWeaponVisualView.GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if(_meleeWeaponController.GetWeaponIsActive() == false)
        {
            _spriteRenderer.color = new Color(1f, 1f, 1f, 0f);
        } else
        {
            _spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
            
        }
        _spriteRenderer.sprite = _meleeWeaponController.GetMeleeWeaponConfig().MeleeWeaponSprite;
    }
}
