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
    PlayerData playerData;
    PlayerAttack playerAttack;
    public bool IsAttacking = false;
    public bool isOnPlatform = false;
    public int FacingDirection = 1;

    void Start()
    {
        playerData = GetComponent<PlayerData>();
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        playerAnimation = GetComponent<PlayerAnimationController>();
        playerAttack = GetComponent<PlayerAttack>();
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        customVelocity.x = horizontal * movementSpeed;
        customVelocity.y = body.velocity.y;
        body.velocity = customVelocity;

        if (isOnPlatform)
        {
            body.velocity += platformRigidBody.velocity;
        }


        // Code so sprite  and hitbox faces correct position.
        if (Input.GetKey(KeyCode.A))
        {
            FacingDirection = -1;
        }

        else if (Input.GetKey(KeyCode.D))
        {
            FacingDirection = 1;
        }

        if (FacingDirection == -1)
        {
            playerAttack.hitBox.transform.position = playerAttack.leftHitBoxPosition.transform.position;
            sprite.flipX = true;
        }

        else if (FacingDirection == 1)
        {
            playerAttack.hitBox.transform.position = playerAttack.rightHitBoxPosition.transform.position;
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
                IsAttacking = false;
            playerAnimation.SetState(PlayerMovementState.Somersault);
        }
        else if (Input.GetKey(KeyCode.A) && isOnJumpingSurface && IsAttacking == false || Input.GetKey(KeyCode.D) && isOnJumpingSurface && IsAttacking == false)
        {
            playerAnimation.SetState(PlayerMovementState.Jogging);
        }

        if (Input.GetMouseButtonDown(0) && isOnJumpingSurface && playerData.currentStamina > 0)
        {
            playerAnimation.SetState(PlayerMovementState.Attack1);
            IsAttacking = true;
        }

        if (Input.GetMouseButtonDown(1) && isOnJumpingSurface && playerData.currentStamina > 0)
        {
            playerAnimation.SetState(PlayerMovementState.Attack2);
            IsAttacking = true;
        }

        if (Input.GetMouseButtonDown(2) && isOnJumpingSurface && playerData.currentStamina > 0)
        {
            playerAnimation.SetState(PlayerMovementState.Attack3);
            IsAttacking = true;
        }

        if (Input.GetKey(KeyCode.Space) && isOnJumpingSurface && IsAttacking == false && playerData.currentSpecial > 0)
        {

            playerAnimation.SetState(PlayerMovementState.SpecialAbility);

        }

    }

    public void EndAttack()
    {
        IsAttacking = false;
        playerAttack.hitBox.enabled = false;
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "MovingPlatform")
        {
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
