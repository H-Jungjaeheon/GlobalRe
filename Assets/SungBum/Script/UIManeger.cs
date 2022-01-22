using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class UIManeger : MonoBehaviour
{
    public Text Timer;
    public Text Day;
    public Text QueChance;

    public RawImage FadePan;
    public Text FadeTxt;

    public RawImage ButtonPan;
    public GameObject ButtonObj;

    public GameObject PolicePan;

    public GameObject Sign;

    public float LimitTime;
    public int ChanceCnt;
    public int DayCnt;

    public int Ending = 0;


    // Start is called before the first frame update
    void Start()
    {
        LimitTime = 5.0f;
        StartCoroutine("FirstDay");
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator DayPatton()
    {
        switch (DayCnt)
        {
            case 1:
                StartCoroutine("PanFadeIn", 0.9f);
                yield return new WaitForSeconds(0.75f);
                Sign.SetActive(true);

                StartCoroutine("TextFadeIn", 0.6f);

                yield return new WaitForSeconds(1.0f);

                StartCoroutine("TextFadeOut", 0.6f);

                yield return new WaitForSeconds(0.75f);
                StartCoroutine("SceondDay");
                StartCoroutine("PanFadeOut", 0.9f);

                break;

            case 2:
                StartCoroutine("PanFadeIn", 0.9f);
                yield return new WaitForSeconds(1.0f);

                PolicePan.SetActive(true);

                while(true)
                {
                    yield return new WaitForSeconds(0.01f);

                    if(Ending != 0)
                    {
                        break;
                    }
                }

                StartCoroutine("ButtonPanFadeIn", 0.9f);
                yield return new WaitForSeconds(1.1f);

                if (Ending == 1)
                {
                    SceneManager.LoadScene("HappyEnding");
                }

                else if (Ending == 2)
                {
                    SceneManager.LoadScene("BadEnding");
                }
                break;
        }

        yield return null;
    }

    IEnumerator FirstDay()
    {
        Day.text = "첫째 날";
        LimitTime = 30.0f;
        DayCnt = 1;
        ChanceCnt = 1;

        while(0 <= LimitTime)
        {
            yield return null;

            QueChance.text = $"질문 기회: {ChanceCnt}번";
            LimitTime -= Time.deltaTime;
            Timer.text = $"밤 까지 남은시간: {Mathf.Round(LimitTime)}분";
        }

        StartCoroutine("DayPatton");
    }

    IEnumerator SceondDay()
    {
        Day.text = "둘째 날";
        LimitTime = 30.0f;
        DayCnt = 2;
        ChanceCnt = 2;

        while (0 <= LimitTime)
        {
            yield return null;

            QueChance.text = $"질문 기회: {ChanceCnt}번";
            LimitTime -= Time.deltaTime;
            Timer.text = $"밤 까지 남은시간: {Mathf.Round(LimitTime)}분";
        }

        StartCoroutine("DayPatton");
    }

    IEnumerator PanFadeIn(float FadeOutTime)
    {
        Debug.Log("Hi");
        Color color = FadePan.color;

        while(color.a < 1.0f)
        {
            color.a += Time.deltaTime / FadeOutTime;
            FadePan.color = color;

            if (color.a >= 1f) color.a = 1f;

            yield return null;
        }
    }

    IEnumerator PanFadeOut(float FadeOutTime)
    {
        Debug.Log("Hi");
        Color color = FadePan.color;

        while (color.a > 0.0f)
        {
            color.a -= Time.deltaTime / FadeOutTime;
            FadePan.color = color;

            if (color.a <= 0.0f) color.a = 0f;

            yield return null;
        }
    }

    IEnumerator TextFadeIn(float FadeOutTime)
    {
        Debug.Log("Hi");
        Color color = FadeTxt.color;

        while (color.a < 1.0f)
        {
            color.a += Time.deltaTime / FadeOutTime;
            FadeTxt.color = color;

            if (color.a >= 1f) color.a = 1f;

            yield return null;
        }
    }

    IEnumerator TextFadeOut(float FadeOutTime)
    {
        Debug.Log("Hi");
        Color color = FadeTxt.color;

        while (color.a > 0.0f)
        {
            color.a -= Time.deltaTime / FadeOutTime;
            FadeTxt.color = color;

            if (color.a <= 0.0f) color.a = 0f;

            yield return null;
        }
    }

    IEnumerator ButtonPanFadeIn(float FadeOutTime)
    {
        ButtonObj.SetActive(true);

        Debug.Log("Hi");
        Color color = ButtonPan.color;

        while (color.a < 1.0f)
        {
            color.a += Time.deltaTime / FadeOutTime;
            ButtonPan.color = color;

            if (color.a >= 1f) color.a = 1f;

            yield return null;
        }
    }

    IEnumerator ButtonPanFadeOut(float FadeOutTime)
    {
        Debug.Log("Hi");
        Color color = ButtonPan.color;

        while (color.a > 0.0f)
        {
            color.a -= Time.deltaTime / FadeOutTime;
            ButtonPan.color = color;

            if (color.a <= 0.0f) color.a = 0f;

            yield return null;
        }
    }

    public void Ending1()
    {
        Ending = 1;
    }

    public void Ending2()
    {
        Ending = 2;
    }
}
