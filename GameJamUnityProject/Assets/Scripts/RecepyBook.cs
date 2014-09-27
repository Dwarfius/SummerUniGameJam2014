using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RecepyBook : MonoBehaviour 
{
    public GUISkin skin;

    [HideInInspector] public List<Recepy> discovered;

    float scrollValue = 0;

    void OnGUI()
    {
        GUI.skin = skin;

        float lowerValue = Screen.height * 4;
        scrollValue = GUI.VerticalSlider(new Rect(Screen.width - 25, Screen.height / 10, 20, Screen.height * 8f / 10f), scrollValue, 0, lowerValue);
        GUI.Box(new Rect(Screen.width * 8f / 10f - 20, Screen.height / 10 - 20, Screen.width * 2f / 10f + 40, Screen.height * 8f / 10f + 40), "");
        GUI.matrix = Matrix4x4.TRS(new Vector3(Screen.width * 8f / 10f, Screen.height / 10, 0), Quaternion.AngleAxis(0, Vector3.up), Vector3.one);
        float yPos = 0;
        GUI.Box(new Rect(0, yPos - scrollValue, 100, 100), "");
        yPos += 100 + 20;
    }
}
