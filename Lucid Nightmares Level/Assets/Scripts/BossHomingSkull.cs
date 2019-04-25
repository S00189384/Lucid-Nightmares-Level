using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HomingSkullState
{
    Idle, //0
    Exploding, //1
    Exploded //2
}

public class BossHomingSkull : MonoBehaviour
{
    public HomingSkullState homingSkullState;
    GameObject player;
    Animator animator;
    Rigidbody2D body;
    public float moveSpeed = 0.2f;
    public float rotation = 2;
    public float distanceToPlayer;
    public float timer;
    public float explodeTime = 1.5f;
    public float explodeRadius = 3;
    public int damage = 30;
    public bool CanExplode = false;


    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        homingSkullState = HomingSkullState.Idle;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {   //Continually move towards the player
        body.velocity = (player.transform.position - transform.position) * moveSpeed;



        distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
        if (distanceToPlayer < 3)
        {
            CanExplode = true;
        }
        if (CanExplode)
        {
            timer += Time.deltaTime;
            rotation += 2f;
            transform.Rotate(0, 0, rotation);
            homingSkullState = HomingSkullState.Exploding;

            if (timer >= explodeTime)
            {      
                body.velocity = Vector2.zero;
                rotation = 0;
                homingSkullState = HomingSkullState.Exploded;
            }
        }

        animator.SetInteger("HomingSkullState", (int)homingSkullState);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Jumpable" || collision.gameObject.tag == "FillerTile")
        {
            DestroySkull();
        }
    }

    //Called during animation.
    public void DestroySkull()
    {
        Destroy(gameObject);
    }
    public void Explosion()
    {
        Collider2D[] hitObjects = Physics2D.OverlapCircleAll(transform.position, explodeRadius);
        for (int i = 0; i < hitObjects.Length; i++)
        {
            if (hitObjects[i].tag == "Player")
                hitObjects[i].GetComponent<PlayerData>().DeductHealth(damage);
                
        }
    }
}
