using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }  
    }

    AudioSource musicSource;
    AudioSource musicSource2;
    AudioSource sfxSource;


    private bool firstMusignSourcePlaying;

    private void Start()
    {
        //create audio source
        musicSource = gameObject.AddComponent<AudioSource>();
        musicSource2 = gameObject.AddComponent<AudioSource>();
        sfxSource = gameObject.AddComponent<AudioSource>();

        /*loop music*/
        musicSource.loop = true;
        musicSource2.loop = true;
    }


    public void PlayMusic(AudioClip musicClip)
    {
        AudioSource activeSource = firstMusignSourcePlaying ? musicSource : musicSource2;
        activeSource.clip = musicClip;
        activeSource.volume = 1;
        activeSource.Play();
    }

    public void PLayMusicWithFade(AudioClip newClip, float transitionTime = 1f)
    {
        AudioSource activeSource = firstMusignSourcePlaying ? musicSource : musicSource2;
        StartCoroutine(UpdateMusicWithFade(activeSource, newClip, transitionTime));
    
    }

    public void PLayMusicWithCrossFade(AudioClip musicClip, float transitionTime = 1f)
    {
        AudioSource activeSource = firstMusignSourcePlaying ? musicSource : musicSource2;
        AudioSource newSource = firstMusignSourcePlaying ? musicSource2 : musicSource;

        firstMusignSourcePlaying = !firstMusignSourcePlaying;

        newSource.clip = musicClip;
        newSource.Play();
         

        StartCoroutine(UpdateMusicWithCrossFade(activeSource, newSource, transitionTime));

    }

    private IEnumerator UpdateMusicWithFade(AudioSource activeSource, AudioClip newClip, float transitionTime)
    {
        if (!activeSource.isPlaying)
            activeSource.Play();

        float t = 0.0f;

        //FadeOut
        for (t = 0; t < transitionTime; t += Time.deltaTime)
        {
            activeSource.volume = (1 - (t / transitionTime));
            yield return null;
        }

        activeSource.Stop();
        activeSource.clip = newClip;
        activeSource.Play();

        //FadeOut in
        for (t = 0; t < transitionTime; t += Time.deltaTime)
        {
            activeSource.volume = (t / transitionTime);
            yield return null;
        }

    }

    private IEnumerator UpdateMusicWithCrossFade(AudioSource orginal, AudioSource newSource, float transitionTime) 
    {
        float t = 0.0f;
        for (t = 0.0f; t <= transitionTime; t += Time.deltaTime)
        {
            orginal.volume = (1 - (t/ transitionTime));
            newSource.volume = (t / transitionTime);
            yield return null;
        }
        orginal.Stop();
    }


    public void PLaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

    public void PLaySFX(AudioClip clip, float volume)
    {
        sfxSource.PlayOneShot(clip, volume);
    }


    public void SetMusicVolume(float volume)
    {
        musicSource.volume = volume;
        musicSource2.volume = volume;
    }

    public void SetSFXVolume(float volume)
    {
        sfxSource.volume = volume;
    }

}
