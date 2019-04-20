using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    public NavigationPath path;

    SpriteRenderer sprite;
    Vector2 currentTarget;
    Rigidbody2D body;

    public bool PickRandomStartNode = false;
    public bool canMove = true;
    public float moveSpeed = 2f;
    public float distanceToNodeTolerance = 0.2f;

    public int currentNodeIndex = 0;

    // Use this for initialization
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        body = GetComponent<Rigidbody2D>();

        if (PickRandomStartNode)
        {
            currentNodeIndex = Random.Range(0, path.NodeCount - 1);
        }

        GetNextNodePosition();
        TeleportToNode();
    }


    void TeleportToNode()
    {
        transform.position = currentTarget;
    }

    void GetNextNodePosition()
    {
        if (currentNodeIndex >= path.NodeCount)
            currentNodeIndex = 0;

        currentTarget = path.GetNodePosition(currentNodeIndex);
        //transform.up = currentTarget - body.position;

        currentNodeIndex++;

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, currentTarget) <= distanceToNodeTolerance)
        {
            GetNextNodePosition();
        }
        else
        {
            sprite.flipX = false;
        }
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            body.MovePosition(Vector2.MoveTowards(transform.position, currentTarget, moveSpeed * Time.deltaTime));
        }

        body.angularVelocity = 0;
    }
}
