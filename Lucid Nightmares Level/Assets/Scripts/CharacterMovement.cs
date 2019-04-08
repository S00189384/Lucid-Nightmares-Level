using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    protected Rigidbody2D body;
    public Vector2 JumpForce = new Vector2(0, 5);
    public Vector2 DashForce = new Vector2(10, 0);
    public bool isOnJumpingSurface = false;
    public float movementSpeed = 5;

    public virtual void Jump()
    {
        body.AddForce(JumpForce, ForceMode2D.Impulse);
    }

    public virtual void Dash(float direction)
    {
        body.AddForce(DashForce * direction, ForceMode2D.Impulse);
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts.Length > 0 && collision.gameObject.tag == "Jumpable" || collision.gameObject.tag == "MovingPlatform")
        {
            ContactPoint2D contact = collision.contacts[0];

            if (Vector3.Dot(contact.normal, Vector3.up) > 0.5)
            {
                isOnJumpingSurface = true;
            }
            else
            {
                isOnJumpingSurface = false;
            }
        }
    }

    protected virtual void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Jumpable" || collision.gameObject.tag == "MovingPlatform")
        {
            isOnJumpingSurface = false;
        }
    }
}
