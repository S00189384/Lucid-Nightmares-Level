using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestPlatformController : MonoBehaviour
{
    public Transform movePosition;
    public float moveSpeed = 1;
    PlayerData playerData;
    Rigidbody2D body;

    bool ShouldMove = false;

	// Use this for initialization
	void Start ()
    {
        body = GetComponent<Rigidbody2D>();
        playerData = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerData>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Vector2.Distance(transform.position, movePosition.position) < 0.5)
        {
            moveSpeed = 0;
        }

        if (playerData.HasKey3 == true && ShouldMove)
        {
            body.velocity = (movePosition.position - transform.position).normalized * moveSpeed;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ShouldMove = true;
        }
    }
}
