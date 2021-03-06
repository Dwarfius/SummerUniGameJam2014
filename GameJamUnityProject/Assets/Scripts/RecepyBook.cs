﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RecepyBook : MonoBehaviour 
{
    public GUISkin skin;

    [HideInInspector] public List<Recepy> discovered = new List<Recepy>();

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
		AudioPlugin.PlayClip(potions[0].name);
    }

    void OnGUI()
    {
        GUI.skin = skin;

        if (level <= potions.Length && potions[level - 1] != null)
        {
            string s = "Target Potion: " + potions[level - 1].name + "\nHint:" + potions[level - 1].GetComponent<Potion>().hint;
            float height = GUI.skin.box.CalcHeight(new GUIContent(s), Screen.width / 5);
            GUI.Box(new Rect(0, 0, Screen.width / 5, height), s);
        }

        if (GUI.Button(new Rect(Screen.width - 120, Screen.height - 70, 120, 70), journal, journalStyle))
        {
            AudioPlugin.PlayClip("book 1");
            animScript.Reset();
        }

        if (!animScript.isOpen || animScript.close) //don't draw if it's closed or closing
            return;

        scrollValue = GUI.VerticalSlider(new Rect(Screen.width - 25, Screen.height / 10, 20, Screen.height * 8f / 10f), scrollValue, 0, scrollValueLimit);

        GUI.matrix = Matrix4x4.TRS(new Vector3(Screen.width * 8f / 10f, Screen.height / 10, 0), Quaternion.AngleAxis(0, Vector3.up), Vector3.one);
        float y = 0;
        for (int i = 0; i < discovered.Count; i++)
        {
            //starting to fill the content
            GUIContent c = new GUIContent();
            if ((discovered[i].result.renderer as SpriteRenderer).sprite != null)
                c.image = (discovered[i].result.renderer as SpriteRenderer).sprite.texture; //adding image

            //starting formatting the text
            c.text = discovered[i].result.name + " (";
            for (int j = 0; j < discovered[i].ingridients.Length; j++)
            {
                c.text += discovered[i].ingridients[j].name;
                if (j != discovered[i].ingridients.Length - 1)
                    c.text += ", ";
            }
            c.text += ")\n" + discovered[i].result.GetComponent<Potion>().description;

            Rect r = new Rect(emptySpace, y, xSize, GUI.skin.label.CalcHeight(c, xSize));
            r.y -= scrollValue; //offseting it because of scrolls

            y += ySize + emptySpace; //adding the height to draw everything correctly

            //if it's bigger than threshhold - don't draw it
			if (r.y >= -ySize && r.y <= Screen.height * 9f / 10f - ySize)
                GUI.Label(r, c);
        }
    }

    public bool Add(Recepy recepy)
    {
        if (!discovered.Contains(recepy))
        {
            scrollValueLimit = discovered.Count * (ySize + emptySpace);
            discovered.Add(recepy);

			if(recepy.result == potions[level-1])
			{
				level ++;
				AudioPlugin.PlayClip(potions[level - 1].name, 3);
			}
			return true;
        }
		return false;
    }

	public void Remove(int amount)
    {
		discovered.RemoveRange(discovered.Count - amount, amount);
	}
}
