using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTrigger : MonoBehaviour
{
    Rigidbody2D body;
    GameObject player;

    public float distanceToPlayer;
    public Vector2 jumpForce = new Vector2(0, 8);
    public float rotation;
    public float maxRotation = 10;



	// Use this for initialization
	void Start ()
    {
        body = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update ()
    {
        distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
        if(distanceToPlayer <= 5)
        {
            if (rotation > maxRotation)
            {
                rotation = maxRotation;
            }
            rotation += 0.5f;
            transform.Rotate(0, 0, rotation);

        }
        else
        {
            rotation = 0;
            transform.Rotate(0, 0, rotation);
        }
		
	}


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            player.GetComponent<Rigidbody2D>().velocity += jumpForce;
        }
    }

}
