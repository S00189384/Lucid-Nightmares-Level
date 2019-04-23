using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BossState
{
    Idle, //0
    Attack1, //1
    Attack2, //2
    Dead, //3
    Evade, //4
    Walk, //5
    Run, //6
    Attack3 //7
}



public class BossMovement : MonoBehaviour
{
    public BossState bossState;
    BossState previousBossState;

    Rigidbody2D body;
    SpriteRenderer sprite;
    PlayerData playerData;
    Animator animator;
    GameObject player;

    public bool IsAwake = true;
    public bool CanAttack = false;
    public int bossDirection;
    public float distanceToPlayer;
    public float distanceToStartAttacking = 3;
    public float distanceToStartRunning = 6;
    public float runSpeed = 4;
    public float distanceToStartWalking = 10;
    public float walkSpeed = 2f;
    public float currentHealth;
    public float maxHealth = 300;


    // Use this for initialization
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerData = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerData>();

        IsAwake = true;
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(IsAwake)
        {
            //So Boss Faces & Moves in right direction.
            if (player.transform.position.x > transform.position.x && currentHealth > 0)
                bossDirection = 1;
            else
                bossDirection = -1;

            if (bossDirection == -1)
            {
                sprite.flipX = true;
            }

            else
            {
                sprite.flipX = false;
            }



            distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

            MoveToPlayer();
         
            //if (Input.GetKey(KeyCode.Alpha0))
            //    bossState = BossState.Idle;
            //if (Input.GetKey(KeyCode.Alpha1))
            //    bossState = BossState.Attack1;
            //if (Input.GetKey(KeyCode.Alpha2))
            //    bossState = BossState.Attack2;
            //if (Input.GetKey(KeyCode.Alpha3))
            //    bossState = BossState.Dead;
            //if (Input.GetKey(KeyCode.Alpha4))
            //    bossState = BossState.Evade;
            //if (Input.GetKey(KeyCode.Alpha5))
            //    bossState = BossState.Walk;
            //if (Input.GetKey(KeyCode.Alpha6))
            //    bossState = BossState.Run;
        }
       

        animator.SetInteger("BossState", (int)bossState);
    }

    public void SetState(BossState newState)
    {
        if (newState != bossState)
        {
            previousBossState = bossState;
            bossState = newState;
        }
    }

    public void MoveToPlayer()
    { 
        //Far from Player.
        if (distanceToPlayer >= distanceToStartWalking)
        {
            SetState(BossState.Run);
            body.velocity = new Vector2(bossDirection, 0) * runSpeed;
        }
        //Closer to Player.
        else if(distanceToPlayer <= distanceToStartWalking && distanceToPlayer >= distanceToStartAttacking)
        {
            SetState(BossState.Walk);
            body.velocity = new Vector2(bossDirection, 0) * walkSpeed;
        }
        else if(distanceToPlayer < distanceToStartAttacking)
        {
            SetState(BossState.Attack1);
            //Attack
        }
    }

    //public void RunToPlayer()
    //{
    //    SetState(BossState.Run);
    //    body.velocity = new Vector2(bossDirection, transform.position.y) * runSpeed;
    //}
    //public void WalkToPlayer()
    //{
    //    SetState(BossState.Walk);
    //    body.velocity = new Vector2(bossDirection, transform.position.y) * walkSpeed;
    //}
}
