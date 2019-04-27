using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathDoorController : MonoBehaviour
{
    ZombieDetector zombieDetector;
    Rigidbody2D body;
    public Transform upPosition;
    public float moveSpeed = 0.1f;

	// Use this for initialization
	void Start ()
    {
        zombieDetector = GameObject.FindGameObjectWithTag("ZombieDetector").GetComponent<ZombieDetector>();
        body = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (zombieDetector.ZombiesInArea != true)
        {
            body.velocity = new Vector2(0, 1) * moveSpeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "StopMoving")
        {
            moveSpeed = 0;
        }

    }
}
