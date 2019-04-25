using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHeadController : MonoBehaviour
{
    public int damage = 20;
    public float rotation = 4;

    private void Update()
    {
        transform.Rotate(0, 0, rotation);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerData>().DeductHealth(damage);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Jumpable" || collision.gameObject.tag == "FillerTile")
        {
            Destroy(gameObject);
        }
    }
}
