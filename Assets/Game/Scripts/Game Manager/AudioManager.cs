using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [Header("Saut de clope")]
    public AudioClip ambianceSautDeClope;

    public AudioClip victoireSautDeClope;
    public AudioClip defaiteSautDeClope;

    [Header("Baby")]
    public AudioClip tirBaby;

    public AudioClip butBaby;
    public AudioClip loupeBaby;

    [Header("Brosse")]
    public AudioClip outil_btd;
    public AudioClip win_btd;
    public AudioClip lose_btd;

    [SerializeField] private AudioClip music;
    [SerializeField] private AudioClip defeatMusic;

    [Header("Audio Sources")]
    [SerializeField] private AudioSource effectAudioSource;

    [SerializeField] private AudioSource musicAudioSource;

    private Dictionary<Audio, AudioClip> _audioClips;

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

        _audioClips = new Dictionary<Audio, AudioClip>
        {
            { Audio.SC_AMBIANCE, ambianceSautDeClope },
            { Audio.SC_WIN, victoireSautDeClope },
            { Audio.SC_LOSE, defaiteSautDeClope },
            { Audio.BC_TIR, tirBaby },
            { Audio.BC_WIN, butBaby },
            { Audio.BC_LOSE, loupeBaby },
            { Audio.BTD_OUTIL, outil_btd },
            { Audio.BTD_WIN, win_btd },
            { Audio.BTD_LOSE, lose_btd },
        };
    }

    public void PlayAudio(Audio situation)
    {
        if (!_audioClips.TryGetValue(situation, out var clip))
        {
            Debug.LogWarning("Situation not found: " + situation);
            return;
        }

        effectAudioSource.clip = clip;
        effectAudioSource.Play();
    }

    public void StopEffects()
    {
        if (effectAudioSource.isPlaying) return;

        effectAudioSource.Stop();
    }
    
    public void StopMusic()
    {
        musicAudioSource.Stop();
    }

    public void RestartMusic()
    {
        musicAudioSource.Stop();

        musicAudioSource.clip   = music;
        musicAudioSource.loop   = true;
        musicAudioSource.volume = 0.1f;
        musicAudioSource.Play();
    }

    public void GameOverAudioMenu()
    {
        musicAudioSource.Stop();
        effectAudioSource.Stop();
        musicAudioSource.loop = false;

        musicAudioSource.clip   = defeatMusic;
        musicAudioSource.volume = 0.5f;
        musicAudioSource.Play();
    }
}