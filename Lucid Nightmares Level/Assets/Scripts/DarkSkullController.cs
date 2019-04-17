using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkSkullController : MonoBehaviour
{
    public int damage = 50;

    //Making sure DarkSkull can go through jumpable tiles.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "FillerTile")
        {
            Destroy(gameObject);
        }
    }

}
