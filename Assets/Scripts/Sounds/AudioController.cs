using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AudioController : MonoBehaviour
{

    public AudioManager.AudioFile[] audioFiles;
    public AudioSource audioSource;

    // Use this for initialization
    void Awake()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        // If the gameObject doesn't have any AudioSources, add one to it 
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();

        AudioManager.audioSources.Add(audioSource);
    }

    private void OnDestroy()
    {
        AudioManager.audioSources.Remove(audioSource);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
