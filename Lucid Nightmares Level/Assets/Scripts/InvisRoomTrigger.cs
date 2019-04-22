using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisRoomTrigger : MonoBehaviour
{
    public bool PlayerNearby = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            PlayerNearby = true;
    }
}
