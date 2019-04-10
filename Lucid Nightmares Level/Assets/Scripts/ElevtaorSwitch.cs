using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevtaorSwitch : MonoBehaviour
{
    public GameObject elevator;
    public bool IsHittable = true;
    public Sprite buttonNotPressed;
    public Sprite buttonPressed;
    ElevtaorController controller;

    void Start()
    {
        controller = elevator.GetComponent<ElevtaorController>();
    }

    private void Update()
    {
        if(IsHittable)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = buttonNotPressed;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = buttonPressed;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && IsHittable)
        {
            controller.Move();
        }
    }
}
