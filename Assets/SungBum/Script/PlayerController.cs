using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float Speed = 3.0f;
    [SerializeField]
    private float JumpPower = 12.0f;

    [SerializeField]
    private Rigidbody2D rigidbody2D;
    [SerializeField]
    private BoxCollider2D boxCollider2D;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private UIManeger uIManeger;

    private bool LadderChk = false;
    private bool IsJump = true;

    public GameObject Simmoon;
    public bool SimmoonChance = false;

    public GameObject Sign;
    public GameObject SignTxt;
    public bool SignChance = false;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        SimmonStart();
        SignStart();
    }

    void PlayerMove()
    {
        float Movex = Input.GetAxis("Horizontal");

        if (Movex == 0.0f)
            animator.SetBool("Walk", false);

        else if (Movex < 0.0f)
        {
            animator.SetBool("Walk", true);
            this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }

        else if (Movex > 0.0f)
        {
            animator.SetBool("Walk", true);
            this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }

        if(uIManeger.LimitTime >= 0)
            this.gameObject.transform.Translate(Movex * Time.deltaTime * Speed, 0.0f, 0.0f);

        if(isLadder)
        {
            float ver = Input.GetAxis("Vertical");

            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, ver * Speed);
            rigidbody2D.gravityScale = 0.0f;
        }

        else
        {
            rigidbody2D.gravityScale = 4.0f;

            if (Input.GetButtonDown("Jump") && IsJump == true)
            {
                IsJump = false;
                rigidbody2D.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
            }
        }
    }

    void SimmonStart()
    {
        if(SimmoonChance)
        {
            if(Input.GetKeyDown(KeyCode.F) && uIManeger.ChanceCnt > 0)
            {
                SimmoonChance = false;
                uIManeger.ChanceCnt--;
                uIManeger.LimitTime -= 30.0f;
            }
        }
    }

    void SignStart()
    {
        if (SignChance)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Sign.SetActive(true);
                SignChance = false;
            }
        }

        else
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Sign.SetActive(false);
            }
        }
    }

    private bool isLadder;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Ladder"))
        {
            isLadder = true;
            animator.SetBool("Letter", true);
        }

        if (other.gameObject.CompareTag("NPC"))
        {
            SimmoonChance = true;
            Simmoon.SetActive(true);
        }

        if (other.gameObject.CompareTag("Sign"))
        {
            SignChance = true;
            SignTxt.SetActive(true);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            IsJump = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ladder"))
        {
            isLadder = false;
            animator.SetBool("Letter", false);
        }

        if (other.gameObject.CompareTag("NPC"))
        {
            SimmoonChance = false;
            Simmoon.SetActive(false);
        }

        if (other.gameObject.CompareTag("Sign"))
        {
            SignChance = false;
            SignTxt.SetActive(false);
        }
    }
}
