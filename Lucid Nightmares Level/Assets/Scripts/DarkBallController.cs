using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkBallController : MonoBehaviour
{
    GameController gameController;
    public int damage = 30;

    private void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            gameController.DeductHealth(damage);
        if (collision.gameObject.tag == "WoodenSpike")
            Destroy(gameObject);
    }

}
