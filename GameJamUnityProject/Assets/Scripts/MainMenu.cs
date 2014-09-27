using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public Sprite menuBackground;
	public Texture2D startButton;
	public Texture2D instructionsButton;
	public Texture2D optionsButton;
	public Texture2D exitButton;
	public Texture2D instructionsTexture;
	public Texture2D optionsTexture;
	public Texture2D backButton;
	public GUIStyle startButtonStyle;
	public GUIStyle instructionButtonStyle;
	public GUIStyle optionsButtonStyle;
	public GUIStyle exitButtonStyle;
	public GUIStyle backButtonStyle;
	public bool optionsButtonPressed;
	public bool instrucButtonPressed;
	public bool mainMenuButtons = true;
	public GUISkin sideScroll;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI(){

		if(mainMenuButtons ==true){
		if(GUI.Button( new Rect(Screen.width/2,Screen.height/2 -100 ,250,80),startButton, startButtonStyle)){
			Application.LoadLevel(1);
			// Insert awesome animation
		}
		}
		if(mainMenuButtons ==true){
		if(GUI.Button(new Rect(Screen.width/2,Screen.height/2,250,80), instructionsButton,instructionButtonStyle)){
			instrucButtonPressed = true;
			mainMenuButtons = false;
			}
		}
		if(instrucButtonPressed == true){
			GUI.DrawTexture(new Rect(Screen.width/2,Screen.height/2, 300, 300), instructionsTexture, ScaleMode.ScaleToFit);
			if(GUI.Button(new Rect(1150,250,20,20), backButton, backButtonStyle)){
				instrucButtonPressed = false;
				mainMenuButtons = true;
			}
		}

		if(mainMenuButtons ==true){
		if(GUI.Button (new Rect(Screen.width/2 +800,Screen.height/2 - 430,140,221),exitButton, exitButtonStyle))
			Application.Quit();
		}

		if(mainMenuButtons ==true){
		if(GUI.Button(new Rect(Screen.width/2,Screen.height/2+100,250,80), optionsButton,optionsButtonStyle)){
			optionsButtonPressed = true;
		}
		}
		if(optionsButtonPressed == true){
			mainMenuButtons = false;
			GUI.DrawTexture(new Rect(Screen.width/2, Screen.height/2,250,80),optionsTexture, ScaleMode.ScaleToFit);
			GUI.Label(new Rect(Screen.width/2-30.0f,230.0f,200.0f,80.0f),"Master Volume:");
				GUI.skin = sideScroll;
			GameDataScript.volume = Mathf.RoundToInt(GUI.HorizontalScrollbar(new Rect(Screen.width/2-100.0f,250.0f,300.0f,40.0f),GameDataScript.volume,10,0,100));
			GUI.Label(new Rect(Screen.width/2-150.0f,250.0f,100.0f,40.0f),GameDataScript.volume.ToString());
			if(GUI.Button(new Rect(1150,250,20,20), backButton, backButtonStyle)){
				optionsButtonPressed = false;
				mainMenuButtons = true;
			}
		}
	}
}
