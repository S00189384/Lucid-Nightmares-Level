using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestPlatformController : MonoBehaviour
{
    public GameObject movePosition;
    public float speed = 1;
    Vector2 direction = new Vector2(-1, 0);
    PlayerData playerData;
    Rigidbody2D body;

	// Use this for initialization
	void Start ()
    {
        body = GetComponent<Rigidbody2D>();
        playerData = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerData>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(playerData.HasKey == true)
        {
            body.velocity = (movePosition.transform.position - transform.position).normalized * speed;
        }

	}

}
