using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spwaner : MonoBehaviour
{

    public static Spwaner Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }


    public float lastPos = -4.5f;
    public GameObject book; 
    bool isLeft;
    public int count;

    GameObject go;

    // Update is called once per frame
    public void BookInit()
    {
        count++;
        lastPos = lastPos + 0.92f;
        var df = 5.34f;
        var pos = new Vector3(isLeft ? -df : df, lastPos, 0);
        go = Instantiate(book, pos, Quaternion.identity);
        go.transform.parent = transform;

        if(Random.Range(0, 3) > 0)
        {
            isLeft = !isLeft;
        }
        
    }

    public void ResetPos()
    {
        var p = go.transform.position ;
        p.x = 0;
        go.transform.position = p;
        count= 0;
    }

     

     
}
