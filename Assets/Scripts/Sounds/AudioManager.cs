using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager> //Singleton nao deleta quando recarregar a cena
{
 public enum ENUM_ArquivosDeSom
    {
        //nomes das faixas a serem chamadas nos codigos
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

[System.Serializable] //para aparecer na aba inspector no unity   
public struct ArquivoSom{

    public ENUM_ArquivosDeSom NomeArquivoSom;
    public AudioClip ArquivoDeSom;

    [Range(0f, 1f)]
    public float Volume;  //Definindo os botoes.    
    [Range(0.1f, 3f)]
    public float Frequencia;

    public bool Loop;
    }

    public static List<AudioSource> FontesDeSom = new List<AudioSource>();

//Criando a funcao play
 public static float Play(GameObject jObjeto, ENUM_ArquivosDeSom arquivo)
    {

        AudioController ControleAudio = jObjeto.GetComponent<AudioController>();
        if (!ControleAudio){
           Debug.Log("Não foi detectado o controle do jogo " + jObjeto.name + " gameObject");  
            return -1f;
        }

AudioSource uFonteDeSom = jObjeto.GetComponent<AudioSource>();
        if (uFonteDeSom == null){
            Debug.Log("No Fonte de Som detected on " + jObjeto.name + " gameObject");
            return -2f;
        }

AudioClip ArquivoDeSom = null; 

float Volume = uFonteDeSom.volume;
float Frequencia = uFonteDeSom.pitch;
bool Loop = uFonteDeSom.loop;
foreach(ArquivoSom arquivoSom in ControleAudio.arquivos){

if(arquivoSom.NomeArquivoSom == arquivo){

    ArquivoDeSom = arquivoSom.ArquivoDeSom;
    Volume = arquivoSom.Volume;
    Frequencia = arquivoSom.Frequencia;
    Loop = arquivoSom.Loop;
    break;
}
}

if (ArquivoDeSom == null)
    return 0f;

uFonteDeSom.clip = ArquivoDeSom;
uFonteDeSom.volume = Volume;
uFonteDeSom.pitch = Frequencia;
uFonteDeSom.loop = Loop;
uFonteDeSom.Play();

return ArquivoDeSom.length;

    }


    public static void PauseAllAudioSources()
    {
        foreach (AudioSource uFonteDeSom in FontesDeSom)
        {
            uFonteDeSom.Pause();
        }
    }

    ///<summary>
    /// Resume all Active AudioSources
    ///</summary>
    public static void ResumeAllAudioSources()
    {
        foreach (AudioSource uFonteDeSom in FontesDeSom)
        {
             uFonteDeSom.UnPause();
        }
    }

    ///<summary>
    /// Mute all Active AudioSources
    ///</summary>
    public static void MuteAllAudioSources()
    {
        foreach (AudioSource uFonteDeSom in FontesDeSom)
        {
             uFonteDeSom.mute = true;
        }
    }

    ///<summary>
    /// Unmute all Active AudioSources
    ///</summary>
    public static void UnmuteAllAudioSources()
    {
        foreach (AudioSource uFonteDeSom in FontesDeSom)
        {
             uFonteDeSom.mute = false;
        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}
