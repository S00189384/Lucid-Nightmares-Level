using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ElevatorState
{
    AtTop, //0
    InMiddle, //1
    AtBottom //2
}

public class MainElevatorController : MonoBehaviour
{
    public ElevatorState elevatorState;
    ElevatorState previousElevatorState;
    Rigidbody2D body;
    public float moveSpeed = 4;
    public Transform topPosition;
    public Transform bottomPosition;
    public Vector2 targetPosition;

	// Use this for initialization
	void Start ()
    {
        body = GetComponent<Rigidbody2D>();
        transform.position = topPosition.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        /*transform.position == topPosition.position*/
        if (transform.position == topPosition.position)
        {
            SetState(ElevatorState.AtTop);
            targetPosition = bottomPosition.position;
        }

        else if (transform.position == bottomPosition.position)
        {
            SetState(ElevatorState.AtBottom);
            targetPosition = topPosition.position;
            Debug.Log("inposition");
        }

        else
        {
            SetState(ElevatorState.InMiddle);
        }

    }


    public void MoveToTarget()
    {
        body.velocity = new Vector2((targetPosition.x - transform.position.x), (targetPosition.y - transform.position.y)) * moveSpeed;
        //body.MovePosition(Vector2.MoveTowards(transform.position, targetPosition.position, moveSpeed * Time.deltaTime));
    }

    public void SetState(ElevatorState newState)
    {
        if (newState != elevatorState)
        {
            previousElevatorState = elevatorState;
            elevatorState = newState;
        }
    }
}
