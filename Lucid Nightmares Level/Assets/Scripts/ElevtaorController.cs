using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevtaorController : MonoBehaviour
{
    ElevtaorSwitch elevtaorSwitch;
    public GameObject elevatorSwitch;
    public float moveSpeed = 2;
    public bool canMove = false;
    public bool isMovingDown = true;
    Rigidbody2D body;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        elevtaorSwitch = elevatorSwitch.GetComponent<ElevtaorSwitch>();
    }

    void Update()
    {

    }

    public void Move()
    {
        if (isMovingDown)
        {
            MoveDown();
        }
        else
        {
            MoveUp();
        }
    }

    public void MoveUp()
    {
        body.velocity = new Vector2(0, 1) * moveSpeed;
        elevtaorSwitch.IsHittable = false;
    }

    public void MoveDown()
    {
        body.velocity = new Vector2(0, -1) * moveSpeed;
        elevtaorSwitch.IsHittable = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "TopElevator" || collision.gameObject.tag == "BottomElevator")
        {
            elevtaorSwitch.IsHittable = true;
            canMove = false;
            isMovingDown = !isMovingDown;
            body.velocity = Vector2.zero;
        }
    }
}
