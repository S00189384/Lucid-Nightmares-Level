using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerMovementState
{
    Idle, //0
    Jogging, //1
    Somersault, //2
    Dash //3
}

public class PlayerAnimationController : MonoBehaviour
{
    public PlayerMovementState playerState;
    PlayerMovementState previousPlayerState;
    Animator animator;

	// Use this for initialization
	void Start ()
    {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        animator.SetInteger("PlayerState", (int)playerState);   
	}

    public void SetState(PlayerMovementState newState)
    {
        if(newState != playerState)
        {
            previousPlayerState = playerState;
            playerState = newState;
        }
    }

}
