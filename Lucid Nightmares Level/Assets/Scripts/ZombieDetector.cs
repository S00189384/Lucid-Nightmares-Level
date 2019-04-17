using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDetector : MonoBehaviour
{
    public bool ZombiesInArea;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Zombie" || collision.gameObject.tag == "SpawnPoint")
        {
            ZombiesInArea = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Zombie" || collision.gameObject.tag == "SpawnPoint")
        {
            ZombiesInArea = false;
        }
    }
}
