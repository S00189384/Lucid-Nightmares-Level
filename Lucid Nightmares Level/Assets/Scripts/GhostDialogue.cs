using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GhostDialogue : MonoBehaviour
{
    GameController gameController;
    DialogueTrigger dialogueTrigger;
    public TextMeshProUGUI ghostDialogue;
    public Image dialogueBox;
    public string[] sentences;
    public float typingSpeed = 2;
    private int index;
    public bool AtEndOfSentence;

    private void Start()
    {
        dialogueTrigger = GameObject.FindGameObjectWithTag("DialogueTrigger").GetComponent<DialogueTrigger>();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    private void Update()
    {
        if (gameController.DialogueActive == false)
        {
            dialogueBox.gameObject.SetActive(false);
        }

        if (gameController.DialogueActive)
        {
            dialogueBox.gameObject.SetActive(true);
            if(AtEndOfSentence == false)
            {
                TypeText();
            }
        }
          
    }

    public void NextSentence()
    {
        if(index < sentences.Length - 1)
        {
            index++;
            ghostDialogue.text = "";
            TypeText();
        }
        else
        {
            gameController.DialogueActive = false;
            gameController.DialogueEnded = true;
            Destroy(GameObject.FindGameObjectWithTag("DialogueTrigger"));
        }
    }

    public void TypeText()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            ghostDialogue.text += letter;
            if (ghostDialogue.text == sentences[index])
            {
                AtEndOfSentence = true;
            }
        }
    }

}
