using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdGhostController : MonoBehaviour
{
    SpriteRenderer sprite;
    public Transform positionToMove;
    public GameObject player;
    Rigidbody2D body;
    public float moveSpeed = 5;
    public float distanceToPlayer;
    public float distanceToStartMoving = 4;
    public bool CanMove = false;

	// Use this for initialization
	void Start ()
    {
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
        if(distanceToPlayer <= distanceToStartMoving)
        {
            CanMove = true;               
        }

        if (CanMove == true)
        {
            sprite.flipX = true;
            body.MovePosition(Vector2.MoveTowards(transform.position, positionToMove.transform.position, moveSpeed * Time.deltaTime));          
        }

        if (Vector2.Distance(transform.position, positionToMove.transform.position) <= 0.5f)
        {
            Destroy(gameObject);
        }
    }

}
