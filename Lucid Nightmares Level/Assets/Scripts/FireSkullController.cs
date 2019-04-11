using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSkullController : MonoBehaviour
{
    public int damage = 30;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Jumpable" || collision.gameObject.tag == "FillerTile")
        {
            Destroy(gameObject);
        }
    }

}
