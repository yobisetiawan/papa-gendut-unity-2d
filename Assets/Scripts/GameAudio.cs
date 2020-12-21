using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAudio : MonoBehaviour
{

    public static GameAudio Instance; 
    

    public AudioClip soundTitle;
    public AudioClip soundGamePlay;
    public AudioClip jump;
    public AudioClip fall;
    public AudioClip suaraGerak;


    private void Awake()
    {  
        if(Instance == null)
        {
            Instance = this;
        } 
    }


    public void PlayBGTitle()
    { 
        AudioManager.Instance.PLayMusicWithCrossFade(soundTitle);
    }


    public void PlayBGGamePlay()
    {
        AudioManager.Instance.PLayMusicWithCrossFade(soundGamePlay);
    }

  

    public void PlayJump()
    {
        AudioManager.Instance.PLaySFX(jump);
    }

    public void PlayFall()
    {
        AudioManager.Instance.PLaySFX(fall);
    }

    public void PlayMove()
    {
        AudioManager.Instance.PLaySFX(suaraGerak);
    }


}
