using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour 
{
    public enum State { Main, Instructions, Options };

	public Texture2D instructionsTexture;
	public Texture2D optionsTexture;
	public GUIStyle startButtonStyle;
	public GUIStyle instructionButtonStyle;
	public GUIStyle optionsButtonStyle;
	public GUIStyle exitButtonStyle;
	public GUIStyle backButtonStyle;
    public State state;
	public GUISkin sideScroll;

	void OnGUI()
    {
        float width = Screen.width / 8;
        float x = Screen.width / 2 - width / 2;
        float y = Screen.height / 4;
        float height = Screen.height / 12;
        float emptySpace = Screen.height / 25;

		if(state == State.Main)
        {    
		    if (GUI.Button(new Rect(x, y, width, height), "", startButtonStyle))
			    Application.LoadLevel(1);
            y += height + emptySpace;

            if (GUI.Button(new Rect(x, y, width, height), "", instructionButtonStyle))
                state = State.Instructions;
            y += height + emptySpace;

            if (GUI.Button(new Rect(x, y, width, height), "", optionsButtonStyle))
                state = State.Options;
            y += height + emptySpace;

            if (GUI.Button(new Rect(x, y, width, height), "", exitButtonStyle))
                Application.Quit();
		}

		if(state == State.Instructions)
        {
			GUI.DrawTexture(new Rect(Screen.width / 2, Screen.height / 2, 300, 300), instructionsTexture, ScaleMode.ScaleToFit);

            if (GUI.Button(new Rect(x, y, width, height), "", backButtonStyle))
                state = State.Main;
		}

		if(state == State.Options)
        {
            GUI.skin = sideScroll;

			GUI.Label(new Rect(x, y, width, height / 2), "Master Volume:");
            y += height / 2;

			GameDataScript.volume = GUI.HorizontalScrollbar(new Rect(x - width, y - height / 10, width * 3, height * 1.5f), GameDataScript.volume, 1, 0, 100);
			GUI.Label(new Rect(x - width * 1.1f, y + height / 5, width / 10, height), ((int)GameDataScript.volume).ToString());
            y += height + emptySpace;

            if (GUI.Button(new Rect(x, y, width, height), "", backButtonStyle))
                state = State.Main;
		}
	}
}
