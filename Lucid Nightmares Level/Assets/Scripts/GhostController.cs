using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GhostState
{
    Spawning, //0
    Idle, //1
    Dissapearing //2
}

public class GhostController : MonoBehaviour
{
    public GhostState ghostState;
    GhostState previousGhostState;
    public GameObject player;
    GhostDialogue ghostDialogue;
    PlayerData playerData;
    Animator animator;
    SpriteRenderer sprite;
    GameController gameController;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        playerData = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerData>();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        ghostDialogue = GameObject.FindGameObjectWithTag("UI").GetComponent<GhostDialogue>();

        SetState(GhostState.Spawning);
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetInteger("GhostState", (int)ghostState);

        if (ghostDialogue.DialogueEnded == true)
        {
            SetState(GhostState.Dissapearing);
        }
    }

    public void SetState(GhostState newState)
    {
        if (newState != ghostState)
        {
            previousGhostState = ghostState;
            ghostState = newState;
        }
    }

    // End of spawn animation, sets State to Idle.
    public void EndOfSpawn()
    {
        SetState(GhostState.Idle);
    }

    // End of Dissapear animation, sprite gets disabled.
    public void Dissapear()
    {
        Destroy(gameObject);
    }

}
