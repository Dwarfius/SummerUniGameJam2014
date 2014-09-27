using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public Sprite menuBackground;
	public Texture2D startButton;
	public Texture2D instructionsButton;
	public Texture2D optionsButton;
	public Texture2D exitButton;
	public Texture2D instructionsTexture;
	public Texture2D closeInstructionsButton;
	public bool instrucButtonPressed;
	public GUIStyle startButtonStyle;
	public GUIStyle instructionButtonStyle;
	public GUIStyle optionsButtonStyle;
	public bool optionsButtonPressed;
	public Texture2D optionsTexture;
	public Texture2D closeOptionsButton;
	public GUIStyle exitButtonStyle;
	public bool mainMenuButtons = true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI(){

		if(mainMenuButtons ==true){
		if(GUI.Button( new Rect(Screen.width/2,Screen.height/2 -100 ,250,80),startButton, startButtonStyle)){
			Application.LoadLevel("TutorialLevel");
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
			if(GUI.Button(new Rect(1150,250,20,20), closeInstructionsButton)){
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
			GUI.DrawTexture(new Rect(Screen.width/2, Screen.height/2,250,80),optionsTexture, ScaleMode.ScaleToFit);
			if(GUI.Button(new Rect(1150,250,20,20), closeOptionsButton))
				optionsButtonPressed = false;
		}
	}
}
