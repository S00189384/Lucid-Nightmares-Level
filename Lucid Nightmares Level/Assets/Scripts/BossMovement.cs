using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    //Teleport Stuff.
    public BoxCollider2D teleportPositions;
    public float teleportDistanceToPlayerTolerance = 5;
    public bool StartTeleportProcess;
    public float teleportTimer;
    public float timeToTeleport = 3;
    //Other scripts.
    BossAttack bossAttack;
    BossAnimationController bossAnimation;
    BossData bossData;
    Rigidbody2D body;
    SpriteRenderer sprite;
    GameObject player;
    //Movement Stuff.
    public bool PlayerInRange;
    public int bossDirection;
    public float distanceToPlayer;
    public float distanceToStartAttacking = 3;
    public float runSpeed = 4;
    public float distanceToStartWalking = 5;
    public float walkSpeed = 2f;

    // Use this for initialization
    void Start()
    {
        bossAttack = GetComponent<BossAttack>();
        bossAnimation = GetComponent<BossAnimationController>();
        bossData = GetComponent<BossData>();
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
        StartTeleportProcess = false;
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

                //Continually getting the distance from boss to player & calculating whether player is in range
                distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
                if (distanceToPlayer < distanceToStartAttacking)
                    PlayerInRange = true;
                else
                    PlayerInRange = false;
             
                //Always moves to player and calls the BossAttack script if the boss can attack 
                MoveToPlayer();

                //Checks if boss is within range to start his teleport process (timer)
                if (StartTeleportProcess)
                {
                    teleportTimer += Time.deltaTime;
                    if (teleportTimer >= timeToTeleport)
                    {
                        bossAnimation.SetState(BossState.Evade);
                    }
                }

                //Testing
                if (Input.GetKey(KeyCode.Alpha0))
                {
                    bossData.currentHealth = 0;
                }

            }
        }

        //If boss is dead.
        else
        {
            bossAnimation.SetState(BossState.Dead);
            body.velocity = Vector2.zero;
        }

    }

    public void MoveToPlayer()
    { 
        //Far from Player.
        if (distanceToPlayer >= distanceToStartWalking)
        {
            bossAnimation.SetState(BossState.Run);
            body.velocity = new Vector2(bossDirection, 0) * runSpeed;
        }
        //Closer to Player.
        else if(distanceToPlayer <= distanceToStartWalking && distanceToPlayer >= distanceToStartAttacking)
        {
            bossAnimation.SetState(BossState.Walk);
            body.velocity = new Vector2(bossDirection, 0) * walkSpeed;
        }
        //Within range to attack, idle animation, stops moving.
        else if(PlayerInRange && bossAttack.Attacking != true)
        {
            StartTeleportProcess = true;
            body.velocity = Vector2.zero;
            bossAnimation.SetState(BossState.Idle);
        }
        //If boss can attack (attack timer reaches time to attack), a random attack is generated.
        else if (PlayerInRange && bossAttack.Attacking == true)
        {
           body.velocity = Vector2.zero;
           bossAnimation.bossState = bossAttack.GenerateRandomAttack();         
        }
    }

    //Ensures the new teleport position is not too close to the player (more than distanceToPlayerTolerance).
    //Teleports boss to a position that is more than distanceToPlayerTolerance away. 
    public void Teleport()
    {
        Vector2 newPosition = GetRandomPosition();     
        while(Vector2.Distance(newPosition,player.transform.position) < teleportDistanceToPlayerTolerance)
        {
            newPosition = GetRandomPosition();
        }

        transform.position = newPosition;
        teleportTimer = 0;
        StartTeleportProcess = false;
    }

    //Returns random position within the teleport bounds.
    public Vector2 GetRandomPosition()
    {
        float minX = teleportPositions.bounds.min.x;
        float maxX = teleportPositions.bounds.max.x;
        float randomX = Random.Range(minX, maxX);
        return new Vector2(randomX, transform.position.y);
    }

}
