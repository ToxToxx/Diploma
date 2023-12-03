using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MeleeWeaponVisualView : MonoBehaviour
{
    [SerializeField] private MeleeWeaponController _meleeWeaponController;
    [SerializeField] private MeleeWeaponVisualView _meleeWeaponVisualView;
    private SwitchItemController _switchItemController;
    private SpriteRenderer _spriteRenderer;

    [Inject]
    public void Construct(SwitchItemController switchItemController)
    {
        _switchItemController = switchItemController;
    }

    private void Awake()
    {
        _spriteRenderer = _meleeWeaponVisualView.GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if(_switchItemController.GetCurrentItemState() == CurrentItemStateModel.CurrentItemState.Primary)
        {
            _spriteRenderer.color = new Color(1f, 1f, 1f, 1f);     
        } else
        {
            _spriteRenderer.color = new Color(1f, 1f, 1f, 0f);
        }
        _spriteRenderer.sprite = _meleeWeaponController.GetMeleeWeaponConfig().MeleeWeaponSprite;
    }
}
