﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ZombieState
{
    Idle, //0
    Walking, //1
    Running, //2
    Attacking, //3
    Dead //4
}

public class ZombieController : MonoBehaviour
{
    public BoxCollider2D hitBox;
    public Transform leftHitBoxPosition;
    public Transform rightHitBoxPosition;

    public ZombieState zombieState;
    ZombieState previousZombieState;

    Animator animator;
    SpriteRenderer sprite;
    GameObject player;
    Rigidbody2D body;

    public bool IsGrounded;
    public bool CanAttack = false;
    public int zombieDirection;
    public float distanceToPlayer;
    public float currentHealth;
    public float maxHealth = 50;
    public float walkSpeed = 0.2f;
    public float runSpeed = 4;
    public int damage = 5;

	// Use this for initialization
	void Start ()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
        currentHealth = maxHealth;
    }
	
	// Update is called once per frame
	void Update ()
    {
        // So Zombie faces right direction.
        if (player.transform.position.x > transform.position.x && currentHealth > 0)
            zombieDirection = 1;
        else
            zombieDirection = -1;

        if (zombieDirection == -1)
        {
            sprite.flipX = true;
            hitBox.transform.position = leftHitBoxPosition.transform.position;
        }

        else
        {
            sprite.flipX = false;
            hitBox.transform.position = rightHitBoxPosition.transform.position;
        }


        distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
  
        if(IsGrounded)
        {
            if(distanceToPlayer <= 7 && distanceToPlayer >= 4)
            {
                WalkToPlayer();
                SetState(ZombieState.Walking);
            }
            else if(distanceToPlayer < 4 && CanAttack == false)
            {
                RunToPlayer();
            }
            else
            {
                SetState(ZombieState.Idle);
                body.velocity = Vector2.zero;
            }

        }
        else
        {
            SetState(ZombieState.Idle);
        }

        if(CanAttack)
        {
            Attack();
        }

        if (currentHealth <= 0)
        {
            body.velocity = Vector2.zero;
            SetState(ZombieState.Dead);
        }

        if (Input.GetKey(KeyCode.H))
        {
            currentHealth = 0;
        }

        animator.SetInteger("ZombieState", (int)zombieState);
    }

    public void SetState(ZombieState newState)
    {
        if (newState != zombieState)
        {
            previousZombieState = zombieState;
            zombieState = newState;
        }
    }

    public void WalkToPlayer()
    {
        SetState(ZombieState.Walking);
        body.velocity = new Vector2(zombieDirection, 0) * walkSpeed;
    }

    public void RunToPlayer()
    {
        SetState(ZombieState.Running);
        body.velocity = new Vector2(zombieDirection, 0) * runSpeed;
    }

    public void Attack()
    {
        SetState(ZombieState.Attacking);
    }

    public void SetHitboxActive()
    {
        hitBox.enabled = true;
    }

    public void EndAttack()
    {
        hitBox.enabled = false;
    }

    //So it can be called at end of death animation.
    public void DestroyObject()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Jumpable")
        {
            IsGrounded = true;
        }

        if(collision.gameObject.tag == "Player")
        {
            CanAttack = true;
        }    
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerHitBox")
        {
            currentHealth -= player.GetComponent<PlayerAttack>().DamageInflicted;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Jumpable")
        {
            IsGrounded = false;
        }
        if (collision.gameObject.tag == "Player")
        {
            CanAttack = false;
        }
    }
}
