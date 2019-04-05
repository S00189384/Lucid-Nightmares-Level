using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : CharacterMovement
{
    public float horizontal, vertical;
    Vector2 customVelocity;
    SpriteRenderer sprite;
    PlayerAnimationController playerAnimation;
    public bool IsAttacking = false;
    public int FacingDirection = 1;

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


        // Code so sprite faces correct position.
        if(Input.GetKey(KeyCode.A))
        {
            FacingDirection = -1;
        }

        else if (Input.GetKey(KeyCode.D))
        {
            FacingDirection = 1;
        }

        if (FacingDirection == -1)
        {
            sprite.flipX = true;
        }

        else if(FacingDirection == 1)
        {
            sprite.flipX = false;
        }



        if (body.velocity.x == 0 && body.velocity.y == 0 && IsAttacking == false)
        {
            playerAnimation.SetState(PlayerMovementState.Idle);
        }

        if (Input.GetKey(KeyCode.W) && isOnJumpingSurface)
        {
            body.velocity = new Vector2(body.velocity.x, 0);
            Jump();

            if (body.velocity.y > 0.5 || body.velocity.y < -0.5)
                playerAnimation.SetState(PlayerMovementState.Somersault);
        }
        else if (Input.GetKey(KeyCode.A) && isOnJumpingSurface || Input.GetKey(KeyCode.D) && isOnJumpingSurface)
        {
            playerAnimation.SetState(PlayerMovementState.Jogging);
        }

        if (Input.GetKey(KeyCode.E) && isOnJumpingSurface)
        {
            Dash(horizontal);
            playerAnimation.SetState(PlayerMovementState.Dash);
        }

        if (Input.GetMouseButton(0) && isOnJumpingSurface)
        {
            playerAnimation.SetState(PlayerMovementState.Attack1);
        }

        if (Input.GetMouseButton(1) && isOnJumpingSurface)
        {
            playerAnimation.SetState(PlayerMovementState.Attack2);
        }

        if (Input.GetMouseButton(2) && isOnJumpingSurface)
        {
            playerAnimation.SetState(PlayerMovementState.Attack3);
        }

        if(Input.GetKey(KeyCode.Space) && isOnJumpingSurface)
        {
            playerAnimation.SetState(PlayerMovementState.SpecialAbility);
        }
    }

}
