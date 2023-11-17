
public class InteractableObjectModel
{
    public string InteractableObjectName { get; set; }
    public bool IsInteractable { get; set; }

    public InteractableObjectModel(string interactableObjectName, bool isInteractable)
    {
        InteractableObjectName = interactableObjectName;
        IsInteractable = isInteractable;
    }
}
