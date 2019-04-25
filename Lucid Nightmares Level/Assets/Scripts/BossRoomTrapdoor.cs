using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoomTrapdoor : MonoBehaviour
{
    GameController gameController;
    SpriteRenderer spriteRenderer;
    Rigidbody2D body;
    public float moveSpeed = 4;
    public Transform movePosition;
    public Sprite redEyedTrapdoor;
    public Light redEyesLight;
	// Use this for initialization
	void Start ()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        body = GetComponent<Rigidbody2D>();
        redEyesLight.enabled = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (gameController.BossFightActive)
        {
            body.MovePosition(Vector2.MoveTowards(transform.position, movePosition.transform.position, moveSpeed * Time.deltaTime));
            if(Vector2.Distance(transform.position,movePosition.transform.position) <= 0.05f)
            {
                spriteRenderer.sprite = redEyedTrapdoor;
                redEyesLight.enabled = true;
            }
        }          
	}
}
