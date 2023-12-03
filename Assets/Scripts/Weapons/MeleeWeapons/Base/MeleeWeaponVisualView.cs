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
        _spriteRenderer.sprite = _meleeWeaponController.GetMeleeWeaponConfig().MeleeWeaponSprite;
    }
}
