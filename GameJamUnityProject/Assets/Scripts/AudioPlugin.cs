using UnityEngine;
using System.Collections;

public class AudioPlugin
{
    public static void PlayClip(string name)
    {
        AudioClip clip = Resources.Load<AudioClip>(name);
        GameObject obj = new GameObject("AudioPlayer");
        AudioSource source = obj.AddComponent<AudioSource>();
        source.clip = clip;
        source.Play();
        GameObject.Destroy(obj, clip.length);
    }
}
