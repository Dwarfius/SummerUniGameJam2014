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


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI(){
		if(GUI.Button( new Rect(10,10,350,50),startButton, startButtonStyle)){
			Application.LoadLevel("TutorialLevel");
			// Insert awesome animation
		}
		if(GUI.Button(new Rect(550,270,300,100), instructionsButton)){
			instrucButtonPressed = true;


		}
		if(instrucButtonPressed == true){
			GUI.DrawTexture(new Rect(300,300, Screen.width/2, Screen.height/2), instructionsTexture, ScaleMode.ScaleToFit);
			if(GUI.Button(new Rect(1150,250,20,20), closeInstructionsButton))
				instrucButtonPressed = false;
		}

		if(GUI.Button (new Rect(500,400,300,100),exitButton))
			Application.Quit();
	}
}
