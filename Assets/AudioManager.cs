using UnityEngine;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    // Singleton instance
    public static AudioManager Instance { get; private set; }

    [Header("Saut de clope")]
    public AudioClip ambianceSautDeClope;
    public AudioClip victoireSautDeClope;
    public AudioClip defaiteSautDeClope;
    [Header("Dentiste")]
    public AudioClip outilDentiste;
    public AudioClip victoireDents;
    [Header("Baby")]
    public AudioClip tirBaby;
    public AudioClip butBaby;
    public AudioClip loupeBaby;
    [Header("Corbeille")]
    public AudioClip clopeCorbeille;
    [Header("Herbe")]
    public AudioClip herbeBrule;
    public AudioClip victoireCorbeille;
    [Header("Taffe")]
    public AudioClip tapeTaffe;
    public AudioClip victoireTaffe;
    public AudioClip defaiteTaffe;
    public AudioClip hearthBeat;

    [SerializeField] private AudioClip music;
    [SerializeField] private AudioClip defeatMusic;

    [SerializeField] private AudioSource effectAudioSource;
    [SerializeField] private AudioSource musicAudioSource;

    private Dictionary<string, AudioClip> _audioClips;

    private void Awake()
    {
        
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        musicAudioSource.loop = true;
        musicAudioSource.clip = music;
        musicAudioSource.Play();


        _audioClips = new Dictionary<string, AudioClip>
        {
            { "Ambiance saut de clope", ambianceSautDeClope },
            { "Victoire saut de clope", victoireSautDeClope },
            { "Defaite saut de clope", defaiteSautDeClope },
            { "Outil dentiste", outilDentiste },
            { "Tir Baby", tirBaby },
            { "But Baby", butBaby },
            { "Loupe Baby", loupeBaby },
            { "Clope Corbeille", clopeCorbeille },
            { "Herbe Brule", herbeBrule },
            { "Victoire Corbeille", victoireCorbeille },
            { "Victoire Dents", victoireDents },
            { "Tape taffe", tapeTaffe },
            { "Victoire Taffe", victoireTaffe },
            { "Defaite Taffe", defaiteTaffe },
            { "Hearth Beat", hearthBeat }
        };
    }

    public void PlayAudio(string situation)
    {
        if (!_audioClips.TryGetValue(situation, out var clip))
        {
            Debug.LogWarning("Situation not found: " + situation);
            return;
        }

        effectAudioSource.clip = clip;
        effectAudioSource.Play();
    }

    public void StopAudio()
    {
        if (!effectAudioSource.isPlaying) return;
        
        effectAudioSource.Stop();
    }

    public void Fail()
    {
        musicAudioSource.Stop();
        effectAudioSource.Stop();
        musicAudioSource.loop = false;

        musicAudioSource.clip = defeatMusic;
        musicAudioSource.Play();
    }
}
