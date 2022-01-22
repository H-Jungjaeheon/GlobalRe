using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DialogueSystem : MonoBehaviour
{
    public Text txtName;
    public Text txtsentence;

    public bool EndText = false;

    Queue<string> sentences = new Queue<string>();
    public Animator anim;
    public void Begin(Dialogue info)
    {
        anim.SetBool("isOpen",true);

        sentences.Clear();

        txtName.text = info.name;
        foreach (var sentence in info.sentences)
        {
            sentences.Enqueue(sentence);

        }
        Next();
    }
    public void Next()
    {
        if(sentences.Count == 0)
        {
            End();
            return;
        }
        //txtsentence.text = sentences.Dequeue();
        txtsentence.text = string.Empty;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentences.Dequeue()));
    }

    IEnumerator TypeSentence(string sentence)
    {
        foreach(var letter in sentence)
        {
            txtsentence.text += letter;
            yield return new WaitForSeconds(0.01f);
        }
    }
    private void End()
    {
        anim.SetBool("isOpen", false);
        txtsentence.text = string.Empty;

        EndText = true;
    }
}
