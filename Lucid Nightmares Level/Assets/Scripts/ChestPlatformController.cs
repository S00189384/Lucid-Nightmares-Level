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
        if (playerData.HasKey3 == true)
        {
            body.MovePosition(Vector2.MoveTowards(transform.position, movePosition.position, moveSpeed * Time.deltaTime));
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        collision.gameObject.transform.SetParent(transform);
    //    }

    //}

    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        collision.gameObject.transform.SetParent(null);
    //    }
    //}


}
