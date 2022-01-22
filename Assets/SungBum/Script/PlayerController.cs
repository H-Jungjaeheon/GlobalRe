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
    private CircleCollider2D circleCollider2D;

    private bool LadderChk = false;
    private bool IsJump = true;

    public GameObject Simmoon;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        circleCollider2D = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }

    void PlayerMove()
    {
        float Movex = Input.GetAxis("Horizontal");

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

    private bool isLadder;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Ladder"))
        {
            isLadder = true;
        }

        if (other.gameObject.CompareTag("NPC"))
        {
            Simmoon.SetActive(true);
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
        }

        if (other.gameObject.CompareTag("NPC"))
        {
            Simmoon.SetActive(false);
        }
    }
}
