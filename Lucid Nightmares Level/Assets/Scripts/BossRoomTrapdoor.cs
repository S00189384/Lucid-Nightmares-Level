using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoomTrapdoor : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    FourthGhostController fourthGhostController;
    Rigidbody2D body;
    public float moveSpeed = 4;
    public Transform movePosition;
    public Sprite redEyedTrapdoor;

	// Use this for initialization
	void Start ()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        body = GetComponent<Rigidbody2D>();
        fourthGhostController = GameObject.FindGameObjectWithTag("GhostMovePlayer").GetComponent<FourthGhostController>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (fourthGhostController.PlayerInBossRoom)
        {
            body.MovePosition(Vector2.MoveTowards(transform.position, movePosition.transform.position, moveSpeed * Time.deltaTime));
            spriteRenderer.sprite = redEyedTrapdoor;          
        }          
	}
}
