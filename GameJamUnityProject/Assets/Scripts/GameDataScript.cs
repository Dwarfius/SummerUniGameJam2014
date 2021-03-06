using UnityEngine;
using System.Collections;

public class GameDataScript : MonoBehaviour {
	

	public static float volume=50;

	public AudioClip Theme;
		
	void Start () 
		{
		// Loading the new scene won't destroy the script
		DontDestroyOnLoad(this);
		// Checks if GameData exists	
		GameObject[] gameDataCheck=GameObject.FindGameObjectsWithTag("GameData");
		// Destroys GameData object when re-accessing the scene 
		if (gameDataCheck.Length>1)
			{
			Destroy(gameObject);
			}
		}
	void OnLevelWasLoaded()
	{
		changeAudio();
	}
	void Update()
		{



		}

	public void changeAudio()
	{
		Object[] everything = GameObject.FindObjectsOfType(typeof(GameObject));
		foreach (Object o in everything)
		{
			GameObject g = (GameObject)o;
			if (g.GetComponent<AudioSource>())
				g.GetComponent<AudioSource>().volume = volume * 0.01f;
		}
	}
}
