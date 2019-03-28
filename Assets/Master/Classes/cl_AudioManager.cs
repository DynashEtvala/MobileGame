using UnityEngine;
using UnityEngine.Audio;
using System;

public class cl_AudioManager : MonoBehaviour
{
    public static cl_AudioManager instance;


    public cl_Sound[] sounds;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        foreach (cl_Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.playOnAwake = s.playOnAwake;
            s.source.mute = s.mute;
        }
    }

    private void Start()
    {
    }

    public void Play(string name)
    {
        cl_Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound " + name + " not found!");
            return;
        }
        else
        {
            s.source.Play();
        }
    }

    public void Stop(string name)
    {
        cl_Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound " + name + " not found!");
            return;
        }
        else
        {
            s.source.Stop();
        }
    }

    public void Mute(string name)
    {
        cl_Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound " + name + " not found!");
            return;
        }
        else
        {
            s.source.mute = !s.source.mute;
        }
    }
}