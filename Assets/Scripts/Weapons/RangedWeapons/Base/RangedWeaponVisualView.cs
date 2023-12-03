using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeaponVisualView : MonoBehaviour
{
    [SerializeField] private RangedWeaponController _rangedWeaponController;
    [SerializeField] private RangedWeaponVisualView _rangedWeaponVisualView;

    private SpriteRenderer _spriteRenderer;
    private void Awake()
    {
        _spriteRenderer = _rangedWeaponVisualView.GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if (_rangedWeaponController.GetWeaponIsActive() == false)
        {
            _spriteRenderer.color = new Color(1f, 1f, 1f, 0f);
        }
        else
        {
            _spriteRenderer.color = new Color(1f, 1f, 1f, 1f);

        }
        _spriteRenderer.sprite = _rangedWeaponController.GetRangedWeaponConfig().RangedWeaponSprite;
    }
}
