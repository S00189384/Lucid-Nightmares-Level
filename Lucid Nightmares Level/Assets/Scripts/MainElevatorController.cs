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
    float distanceToNodeTolerance = 0.2f;
    public ElevatorState elevatorState;
    Rigidbody2D body;
    public float moveSpeed = 4;
    public Transform topPosition;
    public Transform bottomPosition;


	// Use this for initialization
	void Start ()
    {
        body = GetComponent<Rigidbody2D>();
        transform.position = topPosition.position;
	}
	
	// Update is called once per frame
	void Update ()
    {

        if(transform.position == topPosition.position)
        {
            body.MovePosition(Vector2.MoveTowards(transform.position, bottomPosition.position, moveSpeed * Time.deltaTime));
            elevatorState = ElevatorState.AtTop;
        }

        if (transform.position == bottomPosition.position)
        {
            body.MovePosition(Vector2.MoveTowards(transform.position, topPosition.position, moveSpeed * Time.deltaTime));
            elevatorState = ElevatorState.AtBottom;
        }

    }
}
