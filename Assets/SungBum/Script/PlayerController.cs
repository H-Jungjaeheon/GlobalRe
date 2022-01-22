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
                DialogueTrigger.In.SetName("주민1/25세/남");
                DialogueTrigger.In.SetSentance("새벽에 갑자기 큰 소리가 들려서 깻어요.\n어떤사람과 싸우고있는 듯한 느낌이었어요.");
                DialogueTrigger.In.SetSentance("그리고 30분뒤에 큰소리가 한번 더 들렸어요.\n정말 겁에 질린 목소리 였어요.");
                DialogueTrigger.In.SetSentance("그리고 네모 룸메이트가 저한테 찾아왔어요.\n\"근데 너 입가에 빨간색이\" 라고 말하자 마자 혀로 핥아없애더라구요.");
                DialogueTrigger.In.SetSentance("그리고 술에 취해 쓰러졋는데 손에 빨간 무언가가 있더라고요.\n그 집에 사는애들 2명이 있는데 그 둘다 주민3을 좋아하는 걸로 알고 있어요.");
                break;

            case "SqureCha2":
                DialogueTrigger.In.SetName("주민2/25세/남");
                DialogueTrigger.In.SetSentance("저는 네모랑 술을 마시기로 해서 치킨을 시켯어요.\n술은 이미 사놓은 상태 였구요.");
                DialogueTrigger.In.SetSentance("근데 사실 저는 네모여자친구 좋아하고 있엇는데\n 그걸 네모한테 말했더니 화를 내며 욕를 하는거에요.");
                DialogueTrigger.In.SetSentance("그래서 일단 화장실에 들어가서 생각하고 나오는데\n근데 갑자기 네모가 저 화장실 간 사이 치킨 다리를 다 먹어버린 거에요.");
                DialogueTrigger.In.SetSentance("저는 너무 화가나서 크게 화를 내며 서로 싸웟고\n저는 집에서 뛰쳐나와 마을 입구에서 생각하다 주민1집에 갔습니다.");
                break;

            case "CircleCha1":
                DialogueTrigger.In.SetName("주민3/23세/여");
                DialogueTrigger.In.SetSentance("저는 네모가 친구랑 술을 마신다 길래 같이 마실까 하고있었는데\n새벽이라 모르겟지만 누군가가 집에서 누가 뛰쳐 나왔어요. ");
                DialogueTrigger.In.SetSentance("뭐지? 하며 한번 가보려고 준비를 했죠 \n준비를 다하고 가려고 하는데 또 다른 누군가가 나오더라구요.");
                DialogueTrigger.In.SetSentance("새벽이라 누군지 확실히 못봣지만 무언가 들... \n아니에요 근데 어짜피 헤어질려고 했어요 그 쓰레기는 없어져야 되요.");
                break;

            case "CircleCha2":
                DialogueTrigger.In.SetName("주민4/26세/남");
                DialogueTrigger.In.SetSentance("저는 네모마을의 마지막 주문을 받고 근데 \n그 전화를 한 사람이 이상한걸 많이 물어 보길래 짜증이 나서");
                DialogueTrigger.In.SetSentance("반반치킨에 양념을 훨씬 맵게 하고\n둘다 양념으로 넣었어요 그리고 사장님께 치킨을 드렸죠.");
                DialogueTrigger.In.SetSentance("그리고 열쇠는 사장님이 가지고 계시기 때문에 \n저는 정리를 한후 사장님을 기다리고 있엇어요.");
                DialogueTrigger.In.SetSentance("그런데 사장님이 와서 문을 잠그고 집에 가는데\n사장님이 치킨집 앞에 있는 치킨모양 장식품을 들고 가시더라구요.");
                DialogueTrigger.In.SetSentance("그 개새.... 아니에요 안녕히 가세요.");
                break;

            case "TriangleCha1":
                DialogueTrigger.In.SetName("주민5/21세/여");
                DialogueTrigger.In.SetSentance("저는 일을 끝내고 집에 가고 있엇어요 \n근데 저희 마을은 가장 안쪽에 있는 마을이라");
                DialogueTrigger.In.SetSentance("가려면 네모마을과 동그라미마을을 지나서 가야 했어요\n평소처럼 이어폰을 끼고 음악을 들으며 가고있엇는데");
                DialogueTrigger.In.SetSentance("주민2(네모)를 봣는데 불안해 보였어요\n그리고 집에 핸드폰을 보며 갔습니다");
                break;

            case "TriangleCha2":
                DialogueTrigger.In.SetName("주민6/49세/남");
                DialogueTrigger.In.SetSentance("저는 마지막 주문이 들어왔다고 해서 이것만하고 집에 가려고 했습니다.");
                DialogueTrigger.In.SetSentance("근데 배달하러 가니까 그 사람들이 술을 조금 먹은거 같아 보엿습니다.\n그래서 치킨 계산하고 가려고 하는데 갑자기 두명이서 시비를 거는거에요");
                DialogueTrigger.In.SetSentance("치킨이 맛없네 다음부터 시키지말아야겠다. 사장도 별로고 알바생도 전화 하니까 짜증을 내던데 등..");
                DialogueTrigger.In.SetSentance("치킨집에 대한 악담을 퍼부었어요 \n하지만 저는 그래도 손님이다 하고 치킨집 문닫으러 갔습니다.");
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
