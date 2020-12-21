 
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class BookTriggerTop : MonoBehaviour
{
    bool isEnter; 

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player" && isEnter == false)
        { 
            transform.parent.GetComponent<Book>().LandedPlayer();
            Spwaner.Instance.BookInit();
            MyCamera.Instance.TakeUpCamera();
            UI_GamePlay.Instance.SetScore();
            isEnter = true;
        }
    }
}
