using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
 * This component helps coordinate the potion creation, as in it keeps track of currently selected ingridients and then sends them to the
 * PotionFactory for it to find the recepy and the result (if there is one). If the result is found - it'll output it.
 */

public class PotionCreationCoordinator : MonoBehaviour
{
    #region Singleton implementation
    static PotionCreationCoordinator singleton = null;

    public static PotionCreationCoordinator Get()
    {
        if (singleton == null)
            singleton = GameObject.FindGameObjectWithTag("Potion Creation Coordinator").GetComponent<PotionCreationCoordinator>();
        return singleton;
    }
    #endregion

    public GUISkin skin;
    public int sucessfulPotions = 0;
    public int failedAtempts = 0;

    [HideInInspector] public List<GameObject> ingridients = new List<GameObject>();
    [HideInInspector] public string currentDescription = null;

    PotionFactory factory;

    void Awake()
    {
        factory = GameObject.FindGameObjectWithTag("PotionFactory").GetComponent<PotionFactory>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Clear();
    }

    void OnGUI()
    {
        GUI.skin = skin;

        string s;
        if (currentDescription != null)
            s = currentDescription;
        else
        {
            s = "Ingridients selected:";
            foreach (GameObject g in ingridients)
                s += "\n" + g.name;
        }
        GUI.Box(new Rect(Screen.width / 2 - 150, Screen.height - 100, 300, 75), s);
        if(ingridients.Count > 0 && GUI.Button(new Rect(Screen.width / 2 - 40, Screen.height - 150, 80, 40), "Combine"))
            Create();
    }

    public void Add(GameObject ingridient)
    {
        ingridients.Add(ingridient);
    }

    public void Remove(GameObject ingridient)
    {
        ingridients.Remove(ingridient);
    }

    public void Clear()
    {
        ingridients.Clear();
    }

    public void Create()
    {
        if (ingridients.Count > 0)
        {
            Recepy result = factory.CreatePotion(ingridients);
            if (result != null)
            {
                currentDescription = result.result.name + " has been crafted!";
                GameObject g = GameObject.FindGameObjectWithTag("RecepyBook");
                if (g != null && g.GetComponent<RecepyBook>().Add(result))
					sucessfulPotions++;
            }
            else
            {
                currentDescription = "Potion creation failed!";
				failedAtempts++;
				if(failedAtempts == 3)
                {
					failedAtempts = 0;
					sucessfulPotions = 0;
					GameObject g = GameObject.FindGameObjectWithTag("RecepyBook");
					if (g != null)
						g.GetComponent<RecepyBook>().Remove(sucessfulPotions);
				}
			}

            foreach (GameObject ingr in ingridients)
                ingr.GetComponent<Ingridient>().wasAdded = false;
            ingridients.Clear();
        }
    }
}
