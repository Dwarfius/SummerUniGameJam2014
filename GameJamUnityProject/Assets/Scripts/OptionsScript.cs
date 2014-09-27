using UnityEngine;
using System.Collections;

public class OptionsScript : MonoBehaviour {

//The texure to be drawn for the splash screen
public Texture2D backGroundTexture;
public Texture2D backButton;
//width and height of button
public int buttonWidth=100;
public int buttonHeight=30;
//the space between the buttons
public int buttonSpacing=70;
//the start Y position of button
public int buttonYStart=300;
public GUISkin myskin;
	public MainMenu options;

	void Start(){
		GameObject opt = GameObject.Find("Scripts");
		options = opt.GetComponent<MainMenu>();
	}

	void OnGUI()
		{
		GUI.skin = myskin;
		if(options.optionsButtonPressed == true){
		GUI.Label(new Rect(Screen.width/2-30.0f,230.0f,100.0f,40.0f),"Master Volume:");
		// Master sound scroll bar
		GameDataScript.volume = Mathf.RoundToInt(GUI.HorizontalScrollbar(new Rect(Screen.width/2-100.0f,250.0f,400.0f,200.0f),GameDataScript.volume,10,0,100));
		GUI.Label(new Rect(Screen.width/2-150.0f,250.0f,100.0f,40.0f),GameDataScript.volume.ToString());
		}
		//add the "go back" button
		if (GUI.Button(new Rect(10.0f,10.0f,60.0f,50.0f), " "))
			{
			//gameData.GetComponent<GameDataScript>().changeAudio();
			//goes back to the main menu
			StartCoroutine(PlayButtonClick());
			}		
		}
	
	IEnumerator PlayButtonClick()
		{
		audio.Play();
		// Waits end of the clip before moving on
		yield return new WaitForSeconds(audio.clip.length);
		// Loads the main menu
		Application.LoadLevel("MainMenu");
		}

}
