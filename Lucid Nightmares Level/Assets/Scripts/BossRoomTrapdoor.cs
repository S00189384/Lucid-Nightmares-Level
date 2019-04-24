using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoomTrapdoor : MonoBehaviour
{
    PlayerData playerData;
    SpriteRenderer spriteRenderer;
    Rigidbody2D body;
    public float moveSpeed = 4;
    public Transform movePosition;
    public Sprite redEyedTrapdoor;

	// Use this for initialization
	void Start ()
    {
        playerData = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerData>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        body = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (playerData.InBossRoom)
        {
            body.MovePosition(Vector2.MoveTowards(transform.position, movePosition.transform.position, moveSpeed * Time.deltaTime));
            spriteRenderer.sprite = redEyedTrapdoor;          
        }          
	}
}
