using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class UICanvas : MonoBehaviour, IAudioSource
{
    public static UICanvas Instance { get; private set; }
    private AudioSource _audioSource;


    private void Awake()
    {
        Instance = this;

        _audioSource = GetComponent<AudioSource>();
    }

    public void Play()
    {
        _audioSource.Play();
    }

    public void Stop()
    {
        if (_audioSource.isPlaying == false)
            return;

        _audioSource.Stop();
    }
}
