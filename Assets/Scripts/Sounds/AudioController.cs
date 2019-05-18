using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AudioController : MonoBehaviour
{

    public AudioManager.ArquivoSom[] arquivos;
    public AudioSource fonte;

void Awake()
    {
fonte = gameObject.GetComponent<AudioSource>();
if (fonte == null)
    fonte = gameObject.AddComponent<AudioSource>();

AudioManager.FontesDeSom.Add(fonte);

}

private void OnDestroy()
    {
        AudioManager.FontesDeSom.Remove(fonte);
    }

}