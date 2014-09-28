using UnityEngine;
using System.Collections;

public class AudioPlugin
{
    public static void PlayClip(string name, float delay = 0)
    {
        AudioClip clip = Resources.Load<AudioClip>(name);
        GameObject obj = new GameObject("AudioPlayer");
        AudioSource source = obj.AddComponent<AudioSource>();
        source.clip = clip;
		if(delay == 0)
        	source.Play();
		else
			source.PlayDelayed(delay);
        GameObject.Destroy(obj, clip.length + delay);
    }
}
