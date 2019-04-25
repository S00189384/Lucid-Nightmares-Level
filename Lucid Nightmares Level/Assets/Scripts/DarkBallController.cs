using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkBallController : MonoBehaviour
{
    public int damage = 30;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            collision.gameObject.GetComponent<PlayerData>().DeductHealth(damage);
        if (collision.gameObject.tag == "WoodenSpike")
            Destroy(gameObject);
    }
}
