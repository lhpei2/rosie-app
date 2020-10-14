using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class PlayBGM : MonoBehaviour
{
    public AudioSource _audioSource;

    void Start() 
    {
        _audioSource.loop = true;
        PlayMusic();
    }

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayMusic()
    {
        if (_audioSource.isPlaying) return;
        _audioSource.Play();
    }

    public void StopMusic()
    {
        _audioSource.Stop();
    }
}