using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestPlatformController : MonoBehaviour
{
    public Transform movePosition;
    public float moveSpeed = 1;
    Vector2 startingPosition;
    PlayerData playerData;
    Rigidbody2D body;

    bool ShouldMove = false;

	// Use this for initialization
	void Start ()
    {
        body = GetComponent<Rigidbody2D>();
        playerData = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerData>();
        startingPosition = transform.position;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (playerData.HasKey3 == true && ShouldMove)
        {
            // body.MovePosition(Vector2.MoveTowards(transform.position, movePosition.position, moveSpeed * Time.deltaTime));
            body.velocity = (movePosition.position - transform.position).normalized * moveSpeed;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ShouldMove = true;
        }
        else if (collision.gameObject.tag == "StopMoving")
        {
            ShouldMove = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {

    }


}
