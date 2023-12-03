using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class RangedWeaponVisualView : MonoBehaviour
{
    [SerializeField] private RangedWeaponController _rangedWeaponController;
    [SerializeField] private RangedWeaponVisualView _rangedWeaponVisualView;

    private SwitchItemController _switchItemController;
    private SpriteRenderer _spriteRenderer;

    [Inject]
    public void Construct(SwitchItemController switchItemController)
    {
        _switchItemController = switchItemController;
    }
    private void Awake()
    {
        _spriteRenderer = _rangedWeaponVisualView.GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if (_switchItemController.GetCurrentItemState() == CurrentItemStateModel.CurrentItemState.Secondary)
        {
            _spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
            
        }
        else
        {
            _spriteRenderer.color = new Color(1f, 1f, 1f, 0f);
        }
        _spriteRenderer.sprite = _rangedWeaponController.GetRangedWeaponConfig().RangedWeaponSprite;
    }
}
