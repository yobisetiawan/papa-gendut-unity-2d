using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class UI_GamePlay : MonoBehaviour
{
    public static UI_GamePlay Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
     
    public Image fadeImage;
    public GameObject panelGameOver;

    public TMPro.TextMeshProUGUI highScoreText;


    public GameObject panelCounter;
    public TMPro.TextMeshProUGUI counterText;


    int counter;

    private void OnEnable()
    {
        AdManager.OnFinishADRewarded += FinishedWatchAd;
    }

    private void OnDisable()
    {
        AdManager.OnFinishADRewarded -= FinishedWatchAd;
    }

    private void Start()
    {
        panelGameOver.SetActive(false);
        panelCounter.SetActive(false);
        fadeImage.gameObject.SetActive(true);
        fadeImage.DOFade(0, 0.5f).OnComplete(() =>
        { 
            fadeImage.gameObject.SetActive(false);
            Invoke("StartTheGame", 1f);
        });
        highScoreText.text = PlayerPrefs.GetInt(MyPlayerPrefs.HighScore.ToString(), 0).ToString();
         
        GameAudio.Instance.PlayBGGamePlay();
    } 

    void StartTheGame()
    {  
        Spwaner.Instance.BookInit();
    } 

    public void GameOver()
    {
        panelGameOver.SetActive(true);
    }

    public void PLayerWatchAds()
    {
        AdManager.Instance.MyShowRewardedAD();
    }

    void StartCounter() {
        counter--;
        counterText.text = counter.ToString();
       
        if (counter <= 0) {
            PlayerWatchedVideo();
        }
        else
        {
            Invoke("StartCounter", 1f);
        } 
    }

    void FinishedWatchAd() {
        panelGameOver.SetActive(false);
        panelCounter.SetActive(true);
        counter = 4;
        StartCounter();
    }

    void PlayerWatchedVideo() {
        Player.Instance.Revive();
        Spwaner.Instance.ResetPos();
        panelCounter.SetActive(false);
    }

    public void GameRestart()
    {
        fadeImage.gameObject.SetActive(true);
        fadeImage.DOFade(1, 1f).OnComplete(() =>
        {
            SceneManager.LoadScene(MyScenes.GamePlay.ToString());
        }); 
    }

    public void GoToTitle()
    {
        fadeImage.gameObject.SetActive(true);
        fadeImage.DOFade(1, 0.5f).OnComplete(() =>
        {
            AdManager.Instance.MyShowInterstitialAD();
            SceneManager.LoadScene(MyScenes.GameTitle.ToString());
        });

    }

    public TMPro.TextMeshProUGUI scoreText;
    int score;
    public void SetScore()
    {
        score++;
        scoreText.text = score.ToString(); 
        int hg = PlayerPrefs.GetInt(MyPlayerPrefs.HighScore.ToString(), 0);
        if(score > hg)
        {
            PlayerPrefs.SetInt(MyPlayerPrefs.HighScore.ToString(), score);
        }
    }
}
