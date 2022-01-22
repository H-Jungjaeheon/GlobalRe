using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] 
    Image Explanation, Setting;

    // Start is called before the first frame update
    void Start()
    {
        Explanation.transform.DOScale(0, 0).SetEase(Ease.InQuad);
        Setting.transform.DOScale(0, 0).SetEase(Ease.InQuad);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameExit()
    {
        Application.Quit();
    }
    public void GameStart()
    {
        //SceneManager.LoadScene("SunbumScene");
        SceneManager.LoadScene("SunbumScene");
    }
    public void ExplanationButtonClick()
    {
        Explanation.transform.DOScale(1, 0.5f).SetEase(Ease.InQuad);
    }
    public void ExplanationExitButtonClick()
    {
        Explanation.transform.DOScale(0, 0.5f).SetEase(Ease.InQuad);
    }
    public void SettingButtonClick()
    {
        Setting.transform.DOScale(1, 0.5f).SetEase(Ease.InQuad);
    }
    public void SettingExitButtonClick()
    {
        Setting.transform.DOScale(0, 0.5f).SetEase(Ease.InQuad);
    }
}
