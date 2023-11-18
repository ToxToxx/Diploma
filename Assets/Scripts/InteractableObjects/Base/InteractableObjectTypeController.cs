using System;
using static InteractableObjectsConfig;

public class InteractableObjectTypeController
{

    public InteractableObjectTypeController ()
    {

    }

    public IObject InitializeTypeOfModel(InteractableObjectsConfig interactableObjectsConfig)
    {
        InteractableObjectsConfig.TypeOfInteractableObject currentType = interactableObjectsConfig.TypeOfObject;
        switch (currentType)
        {
            case (TypeOfInteractableObject.Base):
                return new InteractableObjectModel(interactableObjectsConfig);
            default:
                return new InteractableObjectModel(interactableObjectsConfig);
        }
        
    }
}
