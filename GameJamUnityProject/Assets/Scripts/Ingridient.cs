using UnityEngine;
using System.Collections;

/*
 * This component is used to select the ingridient and to send them to the PotionCreatonCoordinator. Will be used to handle the animations/effects/sounds later on.
 */
public class Ingridient : MonoBehaviour 
{
    public string[] properties;

    public bool wasAdded;

    void OnMouseDown()
    {
        if (!wasAdded)
            PotionCreationCoordinator.Get().Add(gameObject);
        else
            PotionCreationCoordinator.Get().Remove(gameObject);

        wasAdded = !wasAdded;

        Vector3 pos = transform.position;
        pos.z = 0;
        transform.position = pos;
        Camera.main.GetComponent<TutorialBlock>().Next();
    }

    void OnMouseEnter()
    {
        string s = gameObject.name;
        for (int i = 0; i < properties.Length; i++)
            s += "\n" + properties[i];

        PotionCreationCoordinator.Get().currentDescription = s;
    }

    void OnMouseExit()
    {
        PotionCreationCoordinator.Get().currentDescription = null;
    }
}
