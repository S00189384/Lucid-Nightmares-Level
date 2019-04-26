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
    public float currentHealth;
    public float maxHealth = 50;
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
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update ()
    {
        if (currentHealth <= 0)
            Destroy(gameObject);

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
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), go.GetComponent<Collider2D>());
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerHitBox")
        {
            Debug.Log("Hit by player");
            currentHealth -= player.GetComponent<PlayerAttack>().DamageInflicted;
        }
        if(collision.gameObject.tag == "LightSource")
        {
            currentHealth -= player.GetComponent<PlayerAttack>().DamageInflicted;
        }
    }

}
