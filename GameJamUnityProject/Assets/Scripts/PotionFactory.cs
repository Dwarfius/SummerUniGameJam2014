using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

/*
 * Container to storing all the recepies, filled with hand in the levels.
 */
[System.Serializable] public class Recepy
{
    public GameObject[] ingridients;
    public GameObject result;
}

/*
 * This component does the comparison of ingridients and recepies and tells if there is a recepy and a result for the passed ingridients.
 */
public class PotionFactory : MonoBehaviour 
{
    public List<Recepy> recepies;

    void Awake()
    {
        PotionCreationCoordinator.Get(); //creating it, to kickstart everything
    }

    public GameObject CreatePotion(List<GameObject> ingridients)
    {
        List<Recepy> result = recepies.Where(x =>
        {
            //checking the same amount of arguments for apropriate recepy, not to find a wrong one
            if (x.ingridients.Length != ingridients.Count)
                return false;

            //comparing the ingridients one by one to see if the recepy fits
            foreach (GameObject ingridient1 in x.ingridients)
            {
                bool found = false;
                foreach (GameObject ingridient2 in ingridients)
                {
                    if (ingridient1.name == ingridient2.name)
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                    return false;
            }
            return true;
        }).ToList();
        
        if(result.Count > 1) //safety check, cause those errors can pop up due to human factor
        {
            string content = "";
            foreach(GameObject ingridient in ingridients)
                content += " " + ingridient.name;
            Debug.LogError("There are multiple results for combining of" + content);
        }

        if (result.Count > 0)
            return result[0].result; //found one
        else
            return null; //didn't find one
    }
}
