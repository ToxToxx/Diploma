public interface IInterectableObject 
{
    public string InteractableObjectName { get; set; }
    public bool IsInteractable { get; set; }
    public string DescriptionBoxText { get; set; }
    public virtual void InteractReact() { }

}
