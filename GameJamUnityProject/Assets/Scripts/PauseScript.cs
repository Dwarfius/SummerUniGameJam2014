using UnityEngine;
using System.Collections;

public class PauseScript : MonoBehaviour {

	public enum State { Pause, Game, Instructions, Options, };
	public GUIStyle pauseStyle;
	TextureAnimationScript animScript;
	public State state;
	public GUIStyle backButtonStyle;
	public GUIStyle instructionButtonStyle;
	public GUIStyle optionsButtonStyle;
	public Texture2D instructionsTexture;
	public GUISkin sideScroll;
	public ScrollTextureAnimation scroll;
	public GUIStyle masterVolume;
	public GUIStyle volumeLabel;

	// Use this for initialization
	void Start () {
		scroll = GameObject.FindGameObjectWithTag("Scroll").GetComponent<ScrollTextureAnimation>();
		state = State.Game;
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

		if(state == State.Game){
			if (GUI.Button(new Rect(x*0.1f, y*0.4f, width*0.7f, height), "", pauseStyle))
			{
				scroll.renderer.enabled = true;
				//animScript.Reset();
				state = State.Pause;
			
			}
		}
		if(scroll.open == false){
		if(state == State.Pause){
			if (GUI.Button(new Rect(x*1.15f, y*1.2f, width, height), "", instructionButtonStyle))
				state = State.Instructions;
			y += height + emptySpace;
			
			if (GUI.Button(new Rect(x*1.15f, y*1.2f, width, height), "", optionsButtonStyle))
				state = State.Options;
				y += height + emptySpace;
			if (GUI.Button(new Rect(x*1.15f, y*1.2f, width, height), "", backButtonStyle)){
					state = State.Game;
					scroll.renderer.enabled = false;
					scroll.Reset();
				}
			}

		
		if(state == State.Instructions)
		{
			GUI.DrawTexture(new Rect(Screen.width / 2, Screen.height / 2, 300, 300), instructionsTexture, ScaleMode.ScaleToFit);
			
			if (GUI.Button(new Rect(x, y, width, height), "", backButtonStyle))
				state = State.Game;
		}
		if(scroll.open == false){
		if(state == State.Options)
		{
			GUI.skin = sideScroll;
			
					GUI.Label(new Rect(x*1.15f, y*1.5f, width, height / 2), "Master Volume", masterVolume);
			y += height / 2;
			
			GameDataScript.volume = GUI.HorizontalScrollbar(new Rect(x - width *(-0.3f), y - height / 2 * (-3.5f), width *1.5f, height * 1.5f), GameDataScript.volume, 1, 0, 100);
					GUI.Label(new Rect(x - width *(-0.1f), y + height / 2 *3.5f, width / 10, height), ((int)GameDataScript.volume).ToString(),masterVolume);
			y += height + emptySpace;
			
					if (GUI.Button(new Rect(x*1.15f, y *1.5f, width, height), "", backButtonStyle)){
				state = State.Game;
				scroll.renderer.enabled = false;
				scroll.Reset();
			}
		}
		}

	}
}
}