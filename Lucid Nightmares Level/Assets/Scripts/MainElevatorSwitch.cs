using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainElevatorSwitch : MonoBehaviour
{
    public GameObject elevator;
    public bool IsHittable;
    public Sprite buttonNotPressed;
    public Sprite buttonPressed;
    MainElevatorController elevatorController;

    private void Start()
    {
        elevatorController = elevator.GetComponent<MainElevatorController>();
    }


    private void Update()
    {
        Debug.Log(elevatorController.elevatorState);

        if (elevatorController.elevatorState == ElevatorState.AtTop || elevatorController.elevatorState == ElevatorState.AtBottom)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = buttonNotPressed;
            IsHittable = true;
        }

        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = buttonPressed;
            IsHittable = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && IsHittable)
        {
            elevator.GetComponent<MainElevatorController>().MoveToTarget();
            gameObject.GetComponent<SpriteRenderer>().sprite = buttonPressed;
        }
    }

}
