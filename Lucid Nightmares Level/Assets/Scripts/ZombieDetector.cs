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
            Debug.Log("zombie");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Zombie" || collision.gameObject.tag == "SpawnPoint")
        {
            ZombiesInArea = false;
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Zombie" || collision.gameObject.tag == "SpawnPoint")
    //    {
    //        ZombiesInArea = true;
    //        Debug.Log("zombie");
    //    }
    //}

    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Zombie" || collision.gameObject.tag == "SpawnPoint")
    //    {
    //        ZombiesInArea = false;
    //    }
    //}
}
