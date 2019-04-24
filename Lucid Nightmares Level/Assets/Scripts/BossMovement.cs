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
    //Animation stuff.
    public BossState bossState;
    public BossState previousBossState;
    //Teleport Stuff.
    public BoxCollider2D teleportPositions;
    public float distanceToPlayerTolerance = 5;
    //Other scripts.
    BossData bossData;
    Rigidbody2D body;
    SpriteRenderer sprite;
    PlayerData playerData;
    Animator animator;
    GameObject player;
    //Attack stuff.
    public bool CanAttack = false;
    //Movement Stuff.
    public int bossDirection;
    public float distanceToPlayer;
    public float distanceToStartAttacking = 3;
    public float runSpeed = 4;
    public float distanceToStartWalking = 5;
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
    }

    // Update is called once per frame
    void Update()
    {
        //If boss is alive.
        if (bossData.IsAlive)
        {
            //If boss is awake - it can move and attack.
            if (bossData.IsAwake)
            {
                //So Boss Faces & Moves in right direction.
                if (player.transform.position.x > transform.position.x && bossData.currentHealth > 0)
                {
                    bossDirection = 1;
                }
                else
                {
                    bossDirection = -1;
                }
                if (bossDirection == -1)
                {
                    sprite.flipX = true;
                }
                else
                {
                    sprite.flipX = false;
                }

                //Continually getting the distance from boss to player.
                distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
                //Always moves to player. 
                MoveToPlayer();

                //Testing
                if (Input.GetKey(KeyCode.Alpha0))
                {
                    bossData.currentHealth = 0;
                }

                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    Teleport();
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

        //If boss is dead.
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

    public void Teleport()
    {
        //float minX = teleportPositions.bounds.min.x;
        //float maxX = teleportPositions.bounds.max.x;
        //float randomX = Random.Range(minX, maxX);
        //Vector2 newPosition = new Vector2(randomX, transform.position.y);
        while(Vector2.Distance(transform.position, GetRandomPosition()) > distanceToPlayerTolerance)
        {
            GetRandomPosition();
        }


            transform.position = GetRandomPosition();

    }

    public Vector2 GetRandomPosition()
    {
        float minX = teleportPositions.bounds.min.x;
        float maxX = teleportPositions.bounds.max.x;
        float randomX = Random.Range(minX, maxX);
        return new Vector2(randomX, transform.position.y);
    }
}
