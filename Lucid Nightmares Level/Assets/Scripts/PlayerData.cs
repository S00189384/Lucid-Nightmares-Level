using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public bool HasKey1 = false;
    public bool HasKey2 = false;
    public bool HasKey3 = false;




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

        if(hitObject.tag == "Key3")
        {
            Destroy(hitObject);
            HasKey3 = true;
        }
    }


}
