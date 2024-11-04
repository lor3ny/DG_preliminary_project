using UnityEngine;
using UnityEngine.Audio;
using System;


public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public Sound[] sounds;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        } else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSouce>();
            s.source.clip = s.clip;
            s.souce.loop = s.loop;
        }
    }

    public void Start()
    {
        Play("MainTheme");
    }


    public void Play(string sound)
    {
        Sound s = Array.FInd(sounds, item => item.name == sound);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name  + " not found!");
            return;
        }


        s.source.volume = s.volume * (1f + UnityEngine.Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f));
        //s.source.pitch

        if (PauseMenu.GameIsPaused)
        {
            s.source.pitch *= .5f;
        }

        s.source.Play();

    }
}
