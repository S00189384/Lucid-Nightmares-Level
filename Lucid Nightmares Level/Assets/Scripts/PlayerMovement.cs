using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : CharacterMovement
{
    public float horizontal, vertical;
    Vector2 customVelocity;
    SpriteRenderer sprite;
    PlayerAnimationController playerAnimation;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        playerAnimation = GetComponent<PlayerAnimationController>();
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        customVelocity.x = horizontal * movementSpeed;
        customVelocity.y = body.velocity.y;
        body.velocity = customVelocity;

        if(body.velocity.x < 0)
        {
            sprite.flipX = true;
        }

        else
        {
            sprite.flipX = false;
        }

        if (body.velocity.x == 0 && body.velocity.y == 0)
        {
            playerAnimation.SetState(PlayerMovementState.Idle);
        }

        if (Input.GetKeyDown(KeyCode.A) && isOnJumpingSurface || Input.GetKeyDown(KeyCode.D) && isOnJumpingSurface)
        {
            playerAnimation.SetState(PlayerMovementState.Jogging);
        }
        else if (Input.GetKeyDown(KeyCode.W) && isOnJumpingSurface)
        {
            Jump();
            playerAnimation.SetState(PlayerMovementState.Somersault);
        }

        else if (Input.GetKeyDown(KeyCode.E) && isOnJumpingSurface)
        {
            Dash(horizontal);
        }

    }
}
