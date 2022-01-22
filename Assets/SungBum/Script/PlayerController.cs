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

    public string OtherObjName;

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
                NPCChat();

                SimmoonChance = false;
                uIManeger.ChanceCnt--;
                uIManeger.LimitTime -= 30.0f;
            }
        }
    }

    void NPCChat()
    {
        DialogueTrigger.In.ClearSentance();

        switch (OtherObjName)
        {
            case "SqureCha1":
                DialogueTrigger.In.SetName("�ֹ�1/25��/��");
                DialogueTrigger.In.SetSentance("������ ���ڱ� ū �Ҹ��� ����� �����.\n������ �ο���ִ� ���� �����̾����.");
                DialogueTrigger.In.SetSentance("�׸��� 30�еڿ� ū�Ҹ��� �ѹ� �� ��Ⱦ��.\n���� �̿� ���� ��Ҹ� �����.");
                DialogueTrigger.In.SetSentance("�׸��� �׸� �����Ʈ�� ������ ã�ƿԾ��.\n\"�ٵ� �� �԰��� ��������\" ��� ������ ���� ���� �Ӿƾ��ִ��󱸿�.");
                DialogueTrigger.In.SetSentance("�׸��� ���� ���� �������µ� �տ� ���� ���𰡰� �ִ�����.\n�� ���� ��¾ֵ� 2���� �ִµ� �� �Ѵ� �ֹ�3�� �����ϴ� �ɷ� �˰� �־��.");
                break;

            case "SqureCha2":
                DialogueTrigger.In.SetName("�ֹ�2/25��/��");
                DialogueTrigger.In.SetSentance("���� �׸�� ���� ���ñ�� �ؼ� ġŲ�� ���־��.\n���� �̹� ����� ���� ������.");
                DialogueTrigger.In.SetSentance("�ٵ� ��� ���� �׸���ģ�� �����ϰ� �־��µ�\n �װ� �׸����� ���ߴ��� ȭ�� ���� �带 �ϴ°ſ���.");
                DialogueTrigger.In.SetSentance("�׷��� �ϴ� ȭ��ǿ� ���� �����ϰ� �����µ�\n�ٵ� ���ڱ� �׸� �� ȭ��� �� ���� ġŲ �ٸ��� �� �Ծ���� �ſ���.");
                DialogueTrigger.In.SetSentance("���� �ʹ� ȭ������ ũ�� ȭ�� ���� ���� �Οm��\n���� ������ ���ĳ��� ���� �Ա����� �����ϴ� �ֹ�1���� �����ϴ�.");
                break;

            case "CircleCha1":
                DialogueTrigger.In.SetName("�ֹ�3/23��/��");
                DialogueTrigger.In.SetSentance("���� �׸� ģ���� ���� ���Ŵ� �淡 ���� ���Ǳ� �ϰ��־��µ�\n�����̶� �𸣰����� �������� ������ ���� ���� ���Ծ��. ");
                DialogueTrigger.In.SetSentance("����? �ϸ� �ѹ� �������� �غ� ���� \n�غ� ���ϰ� ������ �ϴµ� �� �ٸ� �������� �������󱸿�.");
                DialogueTrigger.In.SetSentance("�����̶� ������ Ȯ���� ���f���� ���� ��... \n�ƴϿ��� �ٵ� ��¥�� ��������� �߾�� �� ������� �������� �ǿ�.");
                break;

            case "CircleCha2":
                DialogueTrigger.In.SetName("�ֹ�4/26��/��");
                DialogueTrigger.In.SetSentance("���� �׸����� ������ �ֹ��� �ް� �ٵ� \n�� ��ȭ�� �� ����� �̻��Ѱ� ���� ���� ���淡 ¥���� ����");
                DialogueTrigger.In.SetSentance("�ݹ�ġŲ�� ����� �ξ� �ʰ� �ϰ�\n�Ѵ� ������� �־���� �׸��� ����Բ� ġŲ�� �����.");
                DialogueTrigger.In.SetSentance("�׸��� ����� ������� ������ ��ñ� ������ \n���� ������ ���� ������� ��ٸ��� �־����.");
                DialogueTrigger.In.SetSentance("�׷��� ������� �ͼ� ���� ��װ� ���� ���µ�\n������� ġŲ�� �տ� �ִ� ġŲ��� ���ǰ�� ��� ���ô��󱸿�.");
                DialogueTrigger.In.SetSentance("�� ����.... �ƴϿ��� �ȳ��� ������.");
                break;

            case "TriangleCha1":
                DialogueTrigger.In.SetName("�ֹ�5/21��/��");
                DialogueTrigger.In.SetSentance("���� ���� ������ ���� ���� �־���� \n�ٵ� ���� ������ ���� ���ʿ� �ִ� �����̶�");
                DialogueTrigger.In.SetSentance("������ �׸����� ���׶�̸����� ������ ���� �߾��\n���ó�� �̾����� ���� ������ ������ �����־��µ�");
                DialogueTrigger.In.SetSentance("�ֹ�2(�׸�)�� �f�µ� �Ҿ��� �������\n�׸��� ���� �ڵ����� ���� �����ϴ�");
                break;

            case "TriangleCha2":
                DialogueTrigger.In.SetName("�ֹ�6/49��/��");
                DialogueTrigger.In.SetSentance("���� ������ �ֹ��� ���Դٰ� �ؼ� �̰͸��ϰ� ���� ������ �߽��ϴ�.");
                DialogueTrigger.In.SetSentance("�ٵ� ����Ϸ� ���ϱ� �� ������� ���� ���� ������ ���� �������ϴ�.\n�׷��� ġŲ ����ϰ� ������ �ϴµ� ���ڱ� �θ��̼� �ú� �Ŵ°ſ���");
                DialogueTrigger.In.SetSentance("ġŲ�� ������ �������� ��Ű�����ƾ߰ڴ�. ���嵵 ���ΰ� �˹ٻ��� ��ȭ �ϴϱ� ¥���� ������ ��..");
                DialogueTrigger.In.SetSentance("ġŲ���� ���� �Ǵ��� �ۺξ���� \n������ ���� �׷��� �մ��̴� �ϰ� ġŲ�� �������� �����ϴ�.");
                break;
        }

        DialogueTrigger.In.Trigger();
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
            OtherObjName = other.name;
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
            OtherObjName = null;
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
