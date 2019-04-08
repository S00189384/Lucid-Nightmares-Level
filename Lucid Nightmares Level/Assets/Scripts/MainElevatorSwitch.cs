using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainElevatorSwitch : MonoBehaviour
{
    public bool IsHittable;




    public Sprite buttonNotPressed;
    public Sprite buttonPressed;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = buttonPressed;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = buttonNotPressed;
        }
    }
}
