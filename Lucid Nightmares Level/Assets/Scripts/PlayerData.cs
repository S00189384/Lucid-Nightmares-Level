using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public bool HasKey = true;




    private void Start()
    {
        
    }

    private void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        HandleCollision(collision.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        HandleCollision(collision.gameObject);
    }






    public void HandleCollision(GameObject hitObject)
    {
        if(hitObject.tag == "Trapdoor")
        {
            Destroy(hitObject);
        }

        if(hitObject.tag == "Key")
        {
            HasKey = true;
        }
    }


}
