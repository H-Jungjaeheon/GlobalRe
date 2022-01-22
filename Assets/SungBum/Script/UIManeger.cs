using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIManeger : MonoBehaviour
{
    public Text Timer;
    public Text Day;
    public Text QueChance;

    public RawImage FadePan;
    public Text FadeTxt;

    public float LimitTime;
    public int ChanceCnt;
    public int DayCnt;


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

                StartCoroutine("TextFadeIn", 0.6f);

                yield return new WaitForSeconds(1.0f);

                StartCoroutine("TextFadeOut", 0.6f);

                yield return new WaitForSeconds(0.75f);
                StartCoroutine("SceondDay");
                StartCoroutine("PanFadeOut", 0.9f);

                break;

            case 2:

                break;
        }

        yield return null;
    }

    IEnumerator FirstDay()
    {
        Day.text = "ù° ��";
        LimitTime = 5.0f;
        DayCnt = 1;
        ChanceCnt = 1;

        QueChance.text = $"���� ��ȸ: {ChanceCnt}��";

        while(0 <= LimitTime)
        {
            yield return null;

            LimitTime -= Time.deltaTime;
            Timer.text = $"�� ���� �����ð�: {Mathf.Round(LimitTime)}��";
        }

        StartCoroutine("DayPatton");
    }

    IEnumerator SceondDay()
    {
        Day.text = "��° ��";
        LimitTime = 5.0f;
        DayCnt = 2;
        ChanceCnt = 2;

        QueChance.text = $"���� ��ȸ: {ChanceCnt}��";

        while (0 <= LimitTime)
        {
            yield return null;

            LimitTime -= Time.deltaTime;
            Timer.text = $"�� ���� �����ð�: {Mathf.Round(LimitTime)}��";
        }
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
}
