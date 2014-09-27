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

    void OnGUI()
    {
        GUI.skin = skin;

        scrollValue = GUI.VerticalSlider(new Rect(Screen.width - 25, Screen.height / 10, 20, Screen.height * 8f / 10f), scrollValue, 0, scrollValueLimit);
        GUI.Box(new Rect(Screen.width * 8f / 10f - 20, Screen.height / 10 - 20, Screen.width * 2f / 10f + 40, Screen.height * 8f / 10f + 40), "");

        GUI.matrix = Matrix4x4.TRS(new Vector3(Screen.width * 8f / 10f, Screen.height / 10, 0), Quaternion.AngleAxis(0, Vector3.up), Vector3.one);
        for (int i = 0; i < discovered.Count; i++)
        {
            Rect r = calculatedRects[i];
            r.y -= scrollValue; //offseting it because of scroll
            if(r.y >= -ySize && r.y <= Screen.height * 9f / 10f - ySize)
                GUI.Box(r, (discovered[i].result.renderer as SpriteRenderer).sprite.texture);
        }
    }

    public void Add(Recepy recepy)
    {
        if (!discovered.Contains(recepy))
        {
            float y = calculatedRects.Count * (ySize + emptySpace);
            calculatedRects.Add(new Rect(emptySpace, y, xSize, ySize));
            scrollValueLimit = y;
            discovered.Add(recepy);
        }
    }
}
