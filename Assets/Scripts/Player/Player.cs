using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static Player Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }


    Rigidbody2D rb;
    Animator anim;
    [SerializeField] bool isGround;
    [SerializeField] bool isTakeHit;
    float jumpForce = 10f; 

    bool isDie;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        RunThePlayer();

        if (Spwaner.Instance.lastPos - transform.position.y > 2)
        {
            Die();
        }
    }

    

    public void Revive()
    {
        var p = transform.position;
        p.x = 0;
        p.y = Spwaner.Instance.lastPos + 3f;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        transform.rotation = Quaternion.identity; 
        transform.position = p;
        isDie = false;
        isTakeHit = false;
    }

    void RunThePlayer()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && isGround && isTakeHit == false)
        {
            rb.velocity = Vector2.up * jumpForce;
            GameAudio.Instance.PlayJump();
        }

        anim.SetBool("PlayerJump", !isGround);
        BetterJump();
    }

    void BetterJump()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * 2.5f * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetKeyDown(KeyCode.Mouse0))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * 1.5f * Time.deltaTime;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            isGround = true; 
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isGround = false; 
    }

    public void TakeHit(bool isLeft)
    {
        isTakeHit = true;
        rb.constraints = RigidbodyConstraints2D.None; 
        if (isLeft)
        {
            rb.velocity = Vector2.left * jumpForce * 0.8f;
        }
        else
        {
            rb.velocity = Vector2.right * jumpForce * 0.8f;
        }
        Die();


    }

    void Die()
    {
        if (isDie == false)
        {
            isDie = true;
            UI_GamePlay.Instance.GameOver();
            GameAudio.Instance.PlayFall();
        }
    }

}
