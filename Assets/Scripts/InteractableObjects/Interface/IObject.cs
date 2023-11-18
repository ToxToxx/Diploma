public interface IObject 
{
    public string InteractableObjectName { get; set; }
    public bool IsInteractable { get; set; }

    public virtual void InteractReact() { }

}
