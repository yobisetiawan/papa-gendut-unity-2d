using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCamera : MonoBehaviour
{

    Vector3 pos; 
    float targetZoom;
    public Transform palyer;

    public static MyCamera Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }


    private void Start()
    {
        TakeUpCamera();
    }  

    public void TakeUpCamera()
    {
        pos = palyer.position;
        pos.y = pos.y + 3f;
        pos.x = 0;
        pos.z = transform.position.z;
    }

    public void Update()
    { 
        transform.position = Vector3.MoveTowards(transform.position, pos, 1.5f * Time.deltaTime); 
    }
}
