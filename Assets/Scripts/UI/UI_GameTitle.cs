using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class UI_GameTitle : MonoBehaviour
{
    public Transform highScoreWrap;
    public Transform gameTitleWrap;
    public Transform btnPlayWrap;
    public Image fadeImage;


    public TMPro.TextMeshProUGUI highScoreText;



    // Start is called before the first frame update
    void Start()
    { 
        fadeImage.gameObject.SetActive(true);
        fadeImage.DOFade(0, 1f).OnComplete(() =>
        {
            GameAudio.Instance.PlayBGTitle();
            MoveIn();
            fadeImage.gameObject.SetActive(false);
        });

        highScoreText.text = PlayerPrefs.GetInt(MyPlayerPrefs.HighScore.ToString(), 0).ToString();
    }

    void MoveIn()
    {
        btnPlayWrap.DOLocalMoveY(0, 0.6f, true);
        gameTitleWrap.DOLocalMoveY(0, 0.6f, true);
        highScoreWrap.DOScale(Vector3.one, 1f);
    }

    void MoveOut(Action cl = null)
    {
        gameTitleWrap.DOLocalMoveY(3000, 0.8f, true);
        highScoreWrap.DOScale(Vector3.zero, 0.6f);
        btnPlayWrap.DOLocalMoveY(-3000, 1f, true)
            .OnComplete(() =>
            {
                if (cl != null)
                    cl();
               
            });  
    }

    public void GoToGamePlay()
    {
        MoveOut(() =>
        {
            fadeImage.gameObject.SetActive(true);
            fadeImage.DOFade(1, 0.6f).OnComplete(() =>
            {
                SceneManager.LoadScene(MyScenes.GamePlay.ToString());
            });  
        });

    }
}
