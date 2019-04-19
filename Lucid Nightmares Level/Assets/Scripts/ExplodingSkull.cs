using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingSkull : MonoBehaviour
{
    public GameObject player;
    Rigidbody2D body;
    public float rotation = 2;
    public float distanceToPlayer;
    public float timer;
    public float explodeTime = 2;
    public bool CanExplode = false;


	// Use this for initialization
	void Start ()
    {

        body = GetComponent<Rigidbody2D>();


	}
	
	// Update is called once per frame
	void Update ()
    {
        distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
        if(distanceToPlayer < 5)
        {
            CanExplode = true;
        }
        if(CanExplode)
        {
            rotation += 0.10f;
            transform.Rotate(0, 0, rotation);
            timer += Time.deltaTime;

            if(timer >= explodeTime)
            {



            }
        }
	}
}
