using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    AudioSource[] audioSources;
    public AudioClip[] audioClips;
    private void Start()
    {
        audioSources = GetComponents<AudioSource>();
        PlayMusic(0);
    }

    public void PlayMusic(int index)
    {
        audioSources[0].clip = audioClips[index];
        audioSources[0].Play();
    }

    public void PlaySoundEffect(int index)
    {
        audioSources[1].clip = audioClips[index];
        audioSources[1].Play();
    }

    public void StopMusic()
    {
        audioSources[0].Stop();
    }
}
