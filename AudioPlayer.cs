// Component that can be attached to any object to play desired sound
// Place sound file in the sound textbox inside Unity
// Adjust volume, pitch, and looping inside Unity
// To play a sound when a specific event happens, type FindObjectOfType<AudioPlayer>().PlaySound();

using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public AudioClip sound;
    [Range(0f, 1f)]
    public float volume;
    [Range(0.1f, 3f)]
    public float pitch;
    public bool loop;
    
    [HideInInspector]
    public AudioSource source;

    // For sound effects
    public void PlaySound()
    {
        source.Play();
    }
    // Setting up volume, sound clip, and pitch for each sound effect
    void Awake()
    {
        source = gameObject.AddComponent<AudioSource>();
        source.clip = sound;
        source.volume = volume;
        source.pitch = pitch;
        source.loop = loop;
    }

    // For game's theme/background music
    void Start()
    {
        
    }
}
