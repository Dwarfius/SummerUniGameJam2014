using UnityEngine;
using System.Collections;

public class TutorialBlock : MonoBehaviour 
{
    public GameObject[] itemsToUnblock;

    Texture2D blackTexture;
    int current = 0;
    GameObject wall;

	void Start () 
    {
        blackTexture = new Texture2D(1, 1);
        blackTexture.SetPixel(0, 0, Color.black);
        blackTexture.Apply();

        if (itemsToUnblock.Length == 0)
            return;

        GameObject ingridient = itemsToUnblock[current];
        Vector3 pos = ingridient.transform.position;
        pos.z = -2;
        ingridient.transform.position = pos;

        wall = new GameObject("Vision blocker");
        wall.transform.position = new Vector3(0, 0, -1);
        wall.transform.localScale = new Vector3(1000000, 1000000, 1);
        wall.AddComponent<SpriteRenderer>().sprite = Sprite.Create(blackTexture, new Rect(0, 0, 1, 1), Vector2.one / 2);
        wall.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
        wall.AddComponent<BoxCollider2D>();
	}

    public void Next()
    {
        current++;
        if (current >= itemsToUnblock.Length)
        {
            if(wall != null)
                wall.SetActive(false);
            return;
        }

        GameObject ingridient = itemsToUnblock[current];
        Vector3 pos = ingridient.transform.position;
        pos.z = -2;
        ingridient.transform.position = pos;
    }
}
