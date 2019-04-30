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
    PlayerData playerData;
    Animator animator;
    SpriteRenderer sprite;
    GameController gameController;

	// Use this for initialization
	void Start ()
    {
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        playerData = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerData>();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

        SetState(GhostState.Spawning);
	}
	
	// Update is called once per frame
	void Update ()
    {
        animator.SetInteger("GhostState", (int)ghostState);

        //if(player.transform.position.x > transform.position.x && playerData.HasKey3 == false)
        //{
        //    SetState(GhostState.Dissapearing);
        //}

        if(gameController.DialogueEnded == true)
        {
            SetState(GhostState.Dissapearing);
        }


        //// After getting key and going back to portal, ghost reappears with dialogue to the player.
        //else if(playerData.HasKey3 == true)
        //{
        //    sprite.enabled = true;
        //    SetState(GhostState.Idle);
        //}
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
        sprite.enabled = false;
    }
}
