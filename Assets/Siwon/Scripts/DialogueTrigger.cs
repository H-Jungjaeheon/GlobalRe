using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : SingletonMono<DialogueTrigger>
{
    public Dialogue info;

    public void Trigger()
    {
        var system = FindObjectOfType<DialogueSystem>();
        system.Begin(info);
    }

    public void SetName(string Name)
    {
        info.name = Name;
    }

    public void ClearSentance()
    {
        info.sentences.RemoveRange(0, info.sentences.Count);
    }

    public void SetSentance(string Sentance)
    {
        info.sentences.Add(Sentance);
    }
}
