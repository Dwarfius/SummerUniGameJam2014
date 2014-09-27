using UnityEngine;
using System.Collections;

/*
 * This component is used to select the ingridient and to send them to the PotionCreatonCoordinator. Will be used to handle the animations/effects/sounds later on.
 */
public class Ingridient : MonoBehaviour 
{
    public string[] properties;

    bool wasAdded;

    void OnMouseDown()
    {
        if (!wasAdded)
            PotionCreationCoordinator.Get().Add(gameObject);
        else
            PotionCreationCoordinator.Get().Remove(gameObject);
        wasAdded = !wasAdded;
    }

    void OnMouseEnter()
    {
        PotionCreationCoordinator.Get().currentDescription = gameObject.name;
    }

    void OnMouseExit()
    {
        PotionCreationCoordinator.Get().currentDescription = null;
    }
}
