using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObjectView : MonoBehaviour
{
    private InteractableObjectController _interactableObjectController;

    public void Initialize(InteractableObjectController controller)
    {
        this._interactableObjectController = controller;
        _interactableObjectController.OnInteractionWithObject += OnInteractionWithObject;
    }

    private void OnInteractionWithObject(object sender, System.EventArgs e)
    {
        Debug.Log("INTERACT VIEW");
    }
}
