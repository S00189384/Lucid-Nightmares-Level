using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FourthGhostState
{
    Idle, //0
    Dissapearing //1
}

public class FourthGhostController : MonoBehaviour
{
    //public NavigationPath navigationPath;
    public Transform[] ghostNodes;
    public int NodeCount { get { return ghostNodes.Length; } }

    Rigidbody2D body;
    Animator animator;
    GameObject player;

    FourthGhostState fourthGhostState;
    public Transform playerHoldPosition;
    public bool HasPlayer = false;
    public float moveSpeed = 3;
    public float timer;
    public float timeToMove = 2;
    public int targetNode = 0;

	// Use this for initialization
	void Start ()
    {
        fourthGhostState = FourthGhostState.Idle;
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(HasPlayer)
        {
            player.GetComponent<PlayerAnimationController>().SetState(PlayerMovementState.Idle);
            player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            player.transform.position = playerHoldPosition.transform.position;
            timer += Time.deltaTime;
            if(timer >= timeToMove)
            {
                MoveToPosition();
            }
        }

        animator.SetInteger("FourthGhostState", (int)fourthGhostState);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            HasPlayer = true;
        }
    }

    public void DestroyGhost()
    {
        Destroy(gameObject);
    }

    public void MoveToPosition()
    {
        //Continuously move ghost to next node.
        body.MovePosition(Vector2.MoveTowards(transform.position, ghostNodes[targetNode].transform.position, moveSpeed * Time.deltaTime));

        //If ghost reaches last node, drop player & dissapear.
        if(Vector2.Distance(transform.position, ghostNodes[ghostNodes.Length - 1].transform.position) <= 0.5f)
        {
            HasPlayer = false;
            fourthGhostState = FourthGhostState.Dissapearing;
        }
        // If gets near to node then move to next one. 
        if (Vector2.Distance(transform.position, ghostNodes[targetNode].transform.position) <= 0.5f)
        {
            targetNode++;
        }
    }
}
