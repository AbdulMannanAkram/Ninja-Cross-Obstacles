using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Create a singleton instance of the SoundManager so that it can be accessed from any script
    public static SoundManager instance;

    // A list of audio clips to be played
    [SerializeField]
    public List<AudioClip> audioClips;

    // A dictionary to map audio clip names to audio sources
    // public Dictionary<string, AudioSource> audioSources;
        public Dictionary<string, AudioSource> audioSources = new Dictionary<string, AudioSource>();

    // public int number;

    void Awake()
    {
        // Set the instance to this object
        instance = this;

        // Create an audio source for each audio clip and add it to the dictionary
        foreach (AudioClip clip in audioClips)
        {
            AudioSource source = gameObject.AddComponent<AudioSource>();
            source.clip = clip;
            audioSources.Add(clip.name, source);
        }
    }

    // Plays the audio clip with the specified name
    public void PlayClip(string clipName)
    {
        // If the audio clip is not found in the dictionary, don't play the clip
        if (!audioSources.ContainsKey(clipName))
        {
            Debug.LogWarning("Audio clip not found: " + clipName);
            return;
        }

        // Play the audio clip
        AudioSource source = audioSources[clipName];
        source.Play();
    }
}
