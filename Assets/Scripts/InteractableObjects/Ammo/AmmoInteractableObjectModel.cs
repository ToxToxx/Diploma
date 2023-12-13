using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class AmmoInteractableObjectModel : MonoBehaviour,IInterectableObject
{
    [SerializeField]private GameObject _ammoModel;
    [SerializeField] private InteractableObjectsConfig _interactableObjectsConfig;
    private InteractableObjectView _interactableObjectView;

    private PlayerInventoryController _playerInventoryController;

    public string InteractableObjectName { get; set; }
    public bool IsInteractable { get; set; }
    public string DescriptionBoxText { get; set; }

    [Inject]
    public void Construct(PlayerInventoryController playerInventoryController, InteractableObjectView interactableObjectView)
    {
        InteractableObjectName = _interactableObjectsConfig.InteractableObjectName;
        IsInteractable = _interactableObjectsConfig.IsInteractable;
        DescriptionBoxText = _interactableObjectsConfig.DescriptionBoxText;
        _playerInventoryController = playerInventoryController;
        _interactableObjectView = interactableObjectView;
    }

    public void InteractReact()
    {
        if (IsInteractable && _ammoModel.GetComponent<AmmoModel>())
        {
            _playerInventoryController.AddPlayerItem(_ammoModel);
            IsInteractable = false;
            _interactableObjectView.OnInteractionWithObject(DescriptionBoxText);
            Debug.Log("Add ammo");
        }
        else
        {
            Debug.Log(InteractableObjectName + " is not interactable");
        }
    }
}