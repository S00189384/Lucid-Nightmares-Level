using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitBox : MonoBehaviour
{
    PlayerData playerData;
    PlayerAnimationController playerAnimation;

    // Use this for initialization
    void Start ()
    {
        playerData = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerData>();
        playerAnimation = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAnimationController>();
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HandleCollision(collision.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        HandleCollision(collision.gameObject);
    }

    public void HandleCollision(GameObject hitObject)
    {
    }
}
