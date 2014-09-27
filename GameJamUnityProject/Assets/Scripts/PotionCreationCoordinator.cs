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
            singleton = (new GameObject("Potion Coordinator Helper")).AddComponent<PotionCreationCoordinator>();
        return singleton;
    }
    #endregion

    [HideInInspector] public List<GameObject> ingridients = new List<GameObject>();

    PotionFactory factory;

    void Start()
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
        string s = "Ingridients selected:";
        foreach (GameObject g in ingridients)
            s += "\n" + g.name;
        GUI.Box(new Rect(Screen.width / 2 - 200, Screen.height - 300, 400, 270), s);
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
            GameObject result = factory.CreatePotion(ingridients);
            if (result != null)
                Debug.Log(result.name + " has been crafted!");
            else
                Debug.Log("Creation failed");
        }
        else
            Debug.LogWarning("No ingridients!");
    }
}
