using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    SpriteRenderer sprite;
    public Sprite checkpointReached;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            sprite.sprite = checkpointReached;
        }
    }
}
