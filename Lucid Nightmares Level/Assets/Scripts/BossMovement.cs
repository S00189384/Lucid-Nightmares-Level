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
    Attack3, //7
    WakingUp, //8
    PlayingDead //9
}


public class BossMovement : MonoBehaviour
{
    public BossState bossState;
    BossState previousBossState;

    BossData bossData;
    Rigidbody2D body;
    SpriteRenderer sprite;
    PlayerData playerData;
    Animator animator;
    GameObject player;

    public bool CanAttack = false;
    public int bossDirection;
    public float distanceToPlayer;
    public float distanceToStartAttacking = 3;
    public float distanceToStartRunning = 6;
    public float runSpeed = 4;
    public float distanceToStartWalking = 10;
    public float walkSpeed = 2f;


    // Use this for initialization
    void Start()
    {
        bossData = GetComponent<BossData>();
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerData = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerData>();
        //IsAwake = true;

    }

    // Update is called once per frame
    void Update()
    {
        //If boss is alive.
        if(bossData.IsAlive)
        {
            //If boss is awake - it can move and attack.
            if (bossData.IsAwake)
            {
                //So Boss Faces & Moves in right direction.
                if (player.transform.position.x > transform.position.x && bossData.currentHealth > 0)
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

                if (bossData.currentHealth > 0)
                {
                    MoveToPlayer();
                }
                else if (bossData.currentHealth <= 0)
                {
                    SetState(BossState.Dead);
                }

                if (Input.GetKey(KeyCode.Alpha0))
                {
                    bossData.currentHealth = 0;
                }

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

        }

        else
        {
            SetState(BossState.Dead);
            body.velocity = Vector2.zero;
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
        //Within range to attack, idle animation, stops moving & random attacks.
        else if(distanceToPlayer < distanceToStartAttacking)
        {
            body.velocity = Vector2.zero;
            SetState(BossState.Idle);
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
