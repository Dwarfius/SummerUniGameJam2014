using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RecepyBook : MonoBehaviour 
{
    public GUISkin skin;

    [HideInInspector] public List<Recepy> discovered = new List<Recepy>();

    List<Rect> calculatedRects = new List<Rect>();
    float scrollValue = 0;
    float scrollValueLimit = 0;
    float emptySpace = Screen.height / 25;
    float ySize = Screen.height / 12;
    float xSize = Screen.width / 5 - 3 * (Screen.height / 25);

	public GameObject[] potions;
	public int level = 1;
	public Texture2D journal;
	public GUIStyle journalStyle;

    TextureAnimationScript animScript;

    void Start()
    {
        animScript = gameObject.GetComponent<TextureAnimationScript>();
    }

    void OnGUI()
    {
        GUI.skin = skin;

        if (GUI.Button(new Rect(Screen.width - 120, Screen.height - 70, 120, 70), journal, journalStyle))
            animScript.Reset();

        if (!animScript.isOpen || animScript.close) //don't draw if it's closed or closing
            return;

        scrollValue = GUI.VerticalSlider(new Rect(Screen.width - 25, Screen.height / 10, 20, Screen.height * 8f / 10f), scrollValue, 0, scrollValueLimit);

        GUI.matrix = Matrix4x4.TRS(new Vector3(Screen.width * 8f / 10f, Screen.height / 10, 0), Quaternion.AngleAxis(0, Vector3.up), Vector3.one);
        for (int i = 0; i < discovered.Count; i++)
        {
            Rect r = calculatedRects[i];
            r.y -= scrollValue; //offseting it because of scroll
            if (r.y >= -ySize && r.y <= Screen.height * 9f / 10f - ySize)
            {
                GUIContent c = new GUIContent();
                c.image = (discovered[i].result.renderer as SpriteRenderer).sprite.texture;
                c.text = discovered[i].result.name + " = ";
                for (int j = 0; j < discovered[i].ingridients.Length; j++)
                {
                    c.text += discovered[i].ingridients[j].name;
                    if (j != discovered[i].ingridients.Length - 1)
                        c.text += " + ";
                }
                GUI.Label(r, c);
            }
        }
    }

    public bool Add(Recepy recepy)
    {
        if (!discovered.Contains(recepy))
        {
            float y = calculatedRects.Count * (ySize + emptySpace);
            calculatedRects.Add(new Rect(emptySpace, y, xSize, ySize));
            scrollValueLimit = y;
            discovered.Add(recepy);

			if(recepy.result == potions[level-1])
				level ++;
			return true;
        }
		return false;
    }

	public void Remove(int amount)
    {
		discovered.RemoveRange(discovered.Count - amount, amount);
        calculatedRects.RemoveRange(calculatedRects.Count - amount, amount);
	}
}
