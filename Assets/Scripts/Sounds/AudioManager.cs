using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{

    #region Variables

    public enum ENUMAudioFile
    {
        clique,
        impacto,
        impactoapagador,
        levelcompleted,
        morte,
        musicamenu,
        objtgrandevoando,
        objtpequenovoando,
        provavoando,
        relatoriovoando,
    }


    [System.Serializable]
    public struct AudioFile
    {
        public ENUMAudioFile audioFileName;
        public AudioClip audioClip;

        [Range(0f, 1f)]
        public float volume;
        [Range(0.1f, 3f)]
        public float pitch;

        public bool loop;

    }

    public static List<AudioSource> audioSources = new List<AudioSource>();

    #endregion

    // Use this for initialization
    void Start()
    {
    }


    ///<summary>
    /// Plays the audioFile searched by ENUMAudioFile within the gameObject
    ///</summary>
    /// <param name="gameObject">The GameObject who is calling the Play method</param>
    /// <param name="enumAudioFile">The ENUMAudioFile to be played</param>
    /// <returns>The AudioFile file length in milliseconds. Returns 0 if the file wasn't found.
    /// Returns -1 if the gameObject doesn't have an AudioController</returns>
    public static float Play(GameObject gObject, ENUMAudioFile enumAudioFile)
    {

        AudioController audioController = gObject.GetComponent<AudioController>();
        if (!audioController)
        {
            Debug.Log("No AudioController detected on " + gObject.name + " gameObject");
            return -1f;
        }

        AudioSource audioSource = gObject.GetComponent<AudioSource>();

        if (audioSource == null)
        {
            Debug.Log("No AudioSource detected on " + gObject.name + " gameObject");
            return -2f;
        }

        AudioClip audioClip = null;
        float volume = audioSource.volume;
        float pitch = audioSource.pitch;
        bool loop = audioSource.loop;
        foreach (AudioFile audioFile in audioController.audioFiles)
        {
            if (audioFile.audioFileName == enumAudioFile)
            {
                audioClip = audioFile.audioClip;
                volume = audioFile.volume;
                pitch = audioFile.pitch;
                loop = audioFile.loop;
                break;
            }
        }

        if (audioClip == null)
            return 0f;

        audioSource.clip = audioClip;
        audioSource.volume = volume;
        audioSource.pitch = pitch;
        audioSource.loop = loop;
        audioSource.Play();

        return audioClip.length;
    }

    
    ///<summary>
    /// Pause all Active AudioSources
    ///</summary>
    public static void PauseAllAudioSources()
    {
        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.Pause();
        }
    }

    ///<summary>
    /// Resume all Active AudioSources
    ///</summary>
    public static void ResumeAllAudioSources()
    {
        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.UnPause();
        }
    }

    ///<summary>
    /// Mute all Active AudioSources
    ///</summary>
    public static void MuteAllAudioSources()
    {
        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.mute = true;
        }
    }

    ///<summary>
    /// Unmute all Active AudioSources
    ///</summary>
    public static void UnmuteAllAudioSources()
    {
        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.mute = false;
        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}
