using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class BookTriggerLR : MonoBehaviour
{
    bool isEnter;
    public bool isLeft;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && isEnter == false)
        {
            transform.parent.GetComponent<Book>().LandedPlayer(); 
            isEnter = true;
            Player.Instance.TakeHit(isLeft);
        }
    }
}
