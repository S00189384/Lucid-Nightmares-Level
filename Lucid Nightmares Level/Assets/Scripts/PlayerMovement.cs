using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : CharacterMovement
{
    Rigidbody2D platformRigidBody;
    GameObject currentPlatform;
    public float horizontal, vertical;
    Vector2 customVelocity;
    SpriteRenderer sprite;
    PlayerAnimationController playerAnimation;
    public bool IsAttacking = false;
    public bool isOnPlatform = false;
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

        if(isOnPlatform)
        {
            body.velocity += platformRigidBody.velocity;
            Debug.Log(platformRigidBody.velocity);
        }


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

        if (Input.GetMouseButtonDown(0) && isOnJumpingSurface)
        {
            playerAnimation.SetState(PlayerMovementState.Attack1);
            IsAttacking = true;
        }

        if (Input.GetMouseButtonDown(1) && isOnJumpingSurface)
        {
            playerAnimation.SetState(PlayerMovementState.Attack2);
            IsAttacking = true;
        }

        if (Input.GetMouseButtonDown(2) && isOnJumpingSurface)
        {
            playerAnimation.SetState(PlayerMovementState.Attack3);
            IsAttacking = true;
        }

        if(Input.GetKey(KeyCode.Space) && isOnJumpingSurface)
        {
            playerAnimation.SetState(PlayerMovementState.SpecialAbility);
            IsAttacking = true;
        }
    }

    public void EndAttack()
    {
        IsAttacking = false;
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "MovingPlatform")
        {
            Debug.Log("sfgz");
            currentPlatform = collision.gameObject;
            isOnPlatform = true;
            platformRigidBody = currentPlatform.GetComponent<Rigidbody2D>();
        }

        base.OnCollisionEnter2D(collision);
    }

    protected override void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "MovingPlatform")
        {
            currentPlatform = null;
            isOnPlatform = false;
            platformRigidBody = null;
        }

        base.OnCollisionExit2D(collision);
    }

}
