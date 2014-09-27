using UnityEngine;
using System.Collections;

public class TutorialBlock : MonoBehaviour 
{
    public string itemToBlock = "";
    public Texture2D holeTexture;

    Texture2D blackTexture;

	void Start () 
    {
        blackTexture = new Texture2D(1, 1);
        blackTexture.SetPixel(0, 0, Color.black);
        blackTexture.Apply();

        GameObject ingridient = GameObject.Find(itemToBlock);
        Vector3 pos = ingridient.transform.position;
        pos.z = -2;
        ingridient.transform.position = pos;

        GameObject gObj = new GameObject("Vision blocker");
        gObj.transform.position = new Vector3(0, 0, -1);
        gObj.transform.localScale = new Vector3(1000000, 1000000, 1);
        gObj.AddComponent<SpriteRenderer>().sprite = Sprite.Create(blackTexture, new Rect(0, 0, 1, 1), Vector2.one / 2);
        gObj.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
        gObj.AddComponent<BoxCollider2D>();
	}
}
