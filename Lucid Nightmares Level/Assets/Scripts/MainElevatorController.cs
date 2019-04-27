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
    public float moveSpeed = 10;
    public Transform topPosition;
    public Transform bottomPosition;
    Transform targetPosition;
    public bool CanMove = false;

	// Use this for initialization
	void Start ()
    {
        body = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (elevatorState == ElevatorState.AtTop && Vector2.Distance(transform.position, topPosition.position) <= 2)
        {
            SetState(ElevatorState.AtTop);
            targetPosition = bottomPosition;
        }

        else if (elevatorState == ElevatorState.AtBottom && Vector2.Distance(transform.position, bottomPosition.position) <= 2)
        {
            SetState(ElevatorState.AtBottom);
            targetPosition = topPosition;
            Debug.Log("inposition");
        }

        else
        {
            SetState(ElevatorState.InMiddle);
        }
    }

    public void MoveToTarget()
    {
        if (CanMove)
            body.velocity = (targetPosition.position - transform.position).normalized * moveSpeed;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "TopElevator")
        {
            Debug.Log("AtTop");
            targetPosition = bottomPosition;
            SetState(ElevatorState.AtTop);
        }

        else if(collision.gameObject.tag == "BottomElevator")
        {
            targetPosition = topPosition;
            SetState(ElevatorState.AtBottom);
            CanMove = false;
        }
    }
}
