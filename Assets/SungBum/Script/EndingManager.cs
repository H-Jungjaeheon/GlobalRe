using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndingManager : MonoBehaviour
{
    public GameObject GoMainBtn;
    public GameObject SetText;

    public DialogueSystem dialogueSystem;

    public int EndingType = 0;

    // Start is called before the first frame update
    void Start()
    {
        SoundMgr.In.StopBGM();
        SoundMgr.In.StopSFX();

        if (EndingType == 1)
        {
            DialogueTrigger.In.ClearSentance();
            DialogueTrigger.In.SetName("주민6/범인");
            DialogueTrigger.In.SetSentance("아쉽게도");
            DialogueTrigger.In.SetSentance("여기까진인가.....");
            DialogueTrigger.In.SetSentance("...");
            DialogueTrigger.In.SetSentance("..");
            DialogueTrigger.In.SetSentance("뭐 다음에도 기회는 올테니....");
            DialogueTrigger.In.Trigger();
        }

        else if (EndingType == 2)
        {
            DialogueTrigger.In.ClearSentance();
            DialogueTrigger.In.SetName("???");
            DialogueTrigger.In.SetSentance("위험할 뻔 했군...");
            DialogueTrigger.In.SetSentance("아~ 그럼 오늘은 누구 차례일려나");
            DialogueTrigger.In.SetSentance("하하하하하하하하!!");
            DialogueTrigger.In.SetSentance(".....");
            DialogueTrigger.In.Trigger();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(dialogueSystem.EndText == true)
        {
            GoMainBtn.SetActive(true);
            SetText.SetActive(true);
        }
    }

    public void GoMain()
    {
        SoundMgr.In.RePlayBGM();
        SceneManager.LoadScene("Title");
    }
}
