using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class triggerDialogue : MonoBehaviour
{
    public dialogue dialogue;
    public Behaviour dialogueCanvas;
    public Behaviour interactionCanvas;
    bool isTrigger = false;
    public GameObject player;
    private void Start()
    {
      
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") {
            isTrigger = true;
            interactionCanvas.enabled = true;
            interactionCanvas.transform.GetChild(0).GetComponent<Text>().text = this.name +" ile Konuşmak için e bas";
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player") {
            isTrigger = false;
            interactionCanvas.enabled = false;
        }
      
       
    }
    private void Update()
    {
        if (isTrigger)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                interactionCanvas.enabled = false;
                FindObjectOfType<dialogueManager>().startDialogue(dialogue,this.name);
                dialogueCanvas.enabled = true;
            }
        }
    }

}
