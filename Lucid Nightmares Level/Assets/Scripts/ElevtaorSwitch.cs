using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevtaorSwitch : MonoBehaviour
{
    Light switchLight;
    public GameObject elevator;
    public bool IsHittable = true;
    public Sprite buttonNotPressed;
    public Sprite buttonPressed;
    ElevtaorController controller;

    void Start()
    {
        controller = elevator.GetComponent<ElevtaorController>();
        switchLight = GameObject.FindGameObjectWithTag("ElevatorSwitchLight").GetComponent<Light>();
    }

    private void Update()
    {
        if(IsHittable)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = buttonNotPressed;
            switchLight.color = Color.green;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = buttonPressed;
            switchLight.color = Color.red;
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
