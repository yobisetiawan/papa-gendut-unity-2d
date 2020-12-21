using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;


public class UI_Developer : MonoBehaviour
{
    public GameObject fadeImage; 

    // Start is called before the first frame update
    void Start()
    {
        fadeImage.SetActive(false);
        Invoke("FadeImage", 3f);
    }

    void FadeImage()
    {
        fadeImage.SetActive(true);
        fadeImage.GetComponent<Image>().DOFade(1, 0.5f).OnComplete(()=>
        {
            SceneManager.LoadScene(MyScenes.GameTitle.ToString());
        }); 
    }

     
}
