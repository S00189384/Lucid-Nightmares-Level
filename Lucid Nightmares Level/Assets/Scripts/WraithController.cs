using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WraithState
{
    Idle, //0
    RangedAttack //1
}


public class WraithController : MonoBehaviour
{
    public Transform[] Nodes;
    public int NodeCount { get { return Nodes.Length; } }

    WraithState wraithState;

    Rigidbody2D body;
    Animator animator;

    public GameObject objectToShoot;
    public float objectSpeed = 3;
    GameObject player;
    public bool playerWithinRange = false;
    public bool MovingToPosition;
    public float rangeToAttack = 8;
    public float moveSpeed = 3;
    public float moveTimer;
    public float timeToMove = 3;
    public float shootTimer;
    public float attackTime = 3;
    public int nextNode;

	// Use this for initialization
	void Start ()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        PickRandomStartPosition();
        wraithState = WraithState.RangedAttack;
    }

    // Update is called once per frame
    void Update ()
    {
        //Tracking distance to player.
        if (Vector2.Distance(transform.position, player.transform.position) <= rangeToAttack)
            playerWithinRange = true;
        else
            playerWithinRange = false;

        //Shooting at Player.
        if(playerWithinRange)
        {
            shootTimer += Time.deltaTime;
            if(shootTimer >= attackTime)
            {
                wraithState = WraithState.RangedAttack;
                shootTimer = 0;
            }
        }

        //Moving between Nodes.
        if(moveTimer == 0)
        {
            nextNode = Random.Range(0, Nodes.Length);
        }

        moveTimer += Time.deltaTime;

        if (moveTimer >= timeToMove)
        {
            MoveToPosition(Nodes[nextNode]);
        }

        animator.SetInteger("WraithState", (int)wraithState);
    }

    public void ShootRanged()
    {
        GameObject go = Instantiate(objectToShoot, transform.position, Quaternion.identity);
        go.GetComponent<Rigidbody2D>().velocity = (player.transform.position - transform.position).normalized * objectSpeed;
    }

    public void PickRandomStartPosition()
    {
        int randomNumber = Random.Range(0, Nodes.Length);
        transform.position = Nodes[randomNumber].position;
    }

    public void MoveToPosition(Transform positionToMove)
    {
        body.MovePosition(Vector2.MoveTowards(transform.position, positionToMove.transform.position, moveSpeed * Time.deltaTime));
        MovingToPosition = true;
        if(Vector2.Distance(transform.position,positionToMove.transform.position) < 0.1f)
        {
            MovingToPosition = false;
            moveTimer = 0;
        }
    }

    public void ResetToIdle()
    {
        wraithState = WraithState.Idle;
    }

    //public Transform PickNextNodePosition()
    //{
    //    randomNumber = Random.Range(0, Nodes.Length);
    //    return Nodes[randomNumber];
    //}
}
