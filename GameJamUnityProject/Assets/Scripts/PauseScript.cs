using UnityEngine;
using System.Collections;

public class PauseScript : MonoBehaviour {
    /*
	public enum State { None, Game, Instructions, Options, };
	public GUIStyle pauseStyle;
	TextureAnimationScript animScript;
	public State state;

	// Use this for initialization
	void Start () {
		animScript = gameObject.GetComponent<TextureAnimationScript>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{		
		float width = Screen.width / 8;
		float x = Screen.width / 2 - width / 2;
		float y = Screen.height / 4;
		float height = Screen.height / 12;
		float emptySpace = Screen.height / 25;
		if (GUI.Button(new Rect(Screen.width -120,Screen.height-700, 120, 70), "", pauseStyle))
			{
			animScript.Reset();			
			if (GUI.Button(new Rect(x, y, width, height), "", instructionButtonStyle))
				state = State.Instructions;
			y += height + emptySpace;

			if (GUI.Button(new Rect(x, y, width, height), "", optionsButtonStyle))
				state = State.Options;
			y += height + emptySpace;

			if (GUI.Button(new Rect(x, y, width, height), "", exitButtonStyle))
				Application.LoadLevel(0);
			}
		if(state == State.Instructions)
		{
			GUI.DrawTexture(new Rect(Screen.width / 2, Screen.height / 2, 300, 300), instructionsTexture, ScaleMode.ScaleToFit);
			
			if (GUI.Button(new Rect(x, y, width, height), "", backButtonStyle))
				state = State.Game;
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

	}*/
}
