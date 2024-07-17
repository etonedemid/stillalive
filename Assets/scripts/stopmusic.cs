using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stopmusic : MonoBehaviour
{
    public AudioClip audioClip;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource[] audioSources = FindObjectsOfType<AudioSource>();
        AudioSource audioSource = null; // Declare the variable before the loop

        foreach (AudioSource source in audioSources)
        {
            source.Stop();
            audioSource = source; // Assign the value within the loop
        }

        if (audioSource != null) // Check if audioSource is not null
        {
            audioSource.clip = audioClip;
            audioSource.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}