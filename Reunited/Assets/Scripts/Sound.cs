using UnityEngine.Audio;
using UnityEngine;

//Brian Kiss
//11/7/2020
//Sound class, from Brackeys: https://www.youtube.com/watch?v=6OT43pvUyfY
//Controls the clip and volume/pitch.

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;
    [Range(.1f, 3)]
    public float pitch;

    public bool loop;

    [HideInInspector]
    public AudioSource source;
}
