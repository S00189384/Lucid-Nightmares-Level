using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GhostDialogue : MonoBehaviour
{
    DialogueTrigger dialogueTrigger;
    GameObject player;
    public TextMeshProUGUI ghostDialogue;
    public Transform dialoguePlayerPosition;
    public Image dialogueBox;
    public string[] sentences;
    public float typingSpeed = 2;
    private int index;
    public bool AtEndOfSentence;
    public bool DialogueEnded = false;
    public bool DialogueActive = false;

    private void Start()
    {
        dialogueTrigger = GameObject.FindGameObjectWithTag("DialogueTrigger").GetComponent<DialogueTrigger>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (dialogueTrigger.DialogueEnabled == false)
        {
            dialogueBox.gameObject.SetActive(false);
        }

        if (dialogueTrigger.DialogueEnabled)
        {
            player.transform.position = dialoguePlayerPosition.transform.position;
            player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            player.GetComponent<PlayerAnimationController>().SetState(PlayerMovementState.Idle);
            dialogueBox.gameObject.SetActive(true);
            TypeText();
        }

    }

    public void NextSentence()
    {
        if (index < sentences.Length - 1)
        {
            index++;
            ghostDialogue.text = "";
            TypeText();
        }
        else
        {
            dialogueTrigger.DialogueEnabled = false;
            DialogueEnded = true;
            Destroy(GameObject.FindGameObjectWithTag("DialogueTrigger"));
        }
    }

    public void TypeText()
    {
        ghostDialogue.text = sentences[index];
    }

}
