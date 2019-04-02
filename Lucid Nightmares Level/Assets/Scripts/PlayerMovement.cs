using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : CharacterMovement
{
    public float horizontal, vertical;
    Vector2 customVelocity;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        customVelocity.x = horizontal * movementSpeed;
        customVelocity.y = body.velocity.y;
        body.velocity = customVelocity;

        if (Input.GetKeyDown(KeyCode.Space) && isOnJumpingSurface || Input.GetKeyDown(KeyCode.UpArrow) && isOnJumpingSurface || Input.GetKeyDown(KeyCode.W) && isOnJumpingSurface)
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.E) && isOnJumpingSurface)
        {
            Dash(horizontal);
        }

    }
}
