using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour
{ 
    Vector3 pos;
    bool isStoped;

    float speed;

    void Start()
    { 
        pos = transform.position;
        pos.x = Random.Range(-0.5f, 0.5f);
        speed = GetRval();
        GameAudio.Instance.PlayMove();
    }

    private void Update()
    {
        if (transform.position != pos && isStoped == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);
        } 
    }

    float GetRval()
    {
       
      var count = Spwaner.Instance.count; 
        if (count <= 3)
        {
            return 3;
        }

        if (count <=  9)
        {
            return count;
        } 

        return Random.Range(3, 12);
    }

    public void LandedPlayer()
    { 
        isStoped = true; 
    }


}
