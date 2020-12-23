using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class dialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dialogue;
    public string npcName;
    public TextMeshProUGUI dialogueName;
    Queue<string> sentences;

    void Start()
    {
        sentences = new Queue<string>();
 
    }
    public void startDialogue(dialogue dialogue,string name)
    {
        dialogue.createDialogue();
        sentences.Clear();
        foreach (var sentece in dialogue.sentences)
        {   
            sentences.Enqueue(sentece);
        }
        npcName = name;
        nextSentence();
    }

    public void nextSentence()
    {
        string sentence = sentences.Dequeue();
        if (sentences.Count==0 || sentence == "\r\n") 
        { endDialogue();
            return;
        }
        
        if (sentence[0] == '+') {
            dialogueName.text = "Player";
            sentence = sentence.Substring(1);
        }

        if (sentence[0] == '-')
        {
            dialogueName.text = npcName;
            sentence = sentence.Substring(1);
        }
        dialogue.text = sentence;
   


    }
    public void endDialogue()
    {
        FindObjectOfType<triggerDialogue>().dialogueCanvas.enabled=false;
       
    }
}
