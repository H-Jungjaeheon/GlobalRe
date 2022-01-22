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
            DialogueTrigger.In.SetName("�ֹ�6/����");
            DialogueTrigger.In.SetSentance("�ƽ��Ե�");
            DialogueTrigger.In.SetSentance("��������ΰ�.....");
            DialogueTrigger.In.SetSentance("...");
            DialogueTrigger.In.SetSentance("..");
            DialogueTrigger.In.SetSentance("�� �������� ��ȸ�� ���״�....");
            DialogueTrigger.In.Trigger();
        }

        else if (EndingType == 2)
        {
            DialogueTrigger.In.ClearSentance();
            DialogueTrigger.In.SetName("???");
            DialogueTrigger.In.SetSentance("������ �� �߱�...");
            DialogueTrigger.In.SetSentance("��~ �׷� ������ ���� �����Ϸ���");
            DialogueTrigger.In.SetSentance("����������������!!");
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
