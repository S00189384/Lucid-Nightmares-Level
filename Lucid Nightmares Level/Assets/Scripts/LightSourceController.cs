using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LightSourceController : MonoBehaviour
{
    Rigidbody2D body;
    public float elapsedTime;
    public float damage = 50;
    public float destroyTime = 7;
    public float visibleRadius = 5;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= destroyTime)
            Destroy(gameObject);

        InvisibleTileShowHide();
    }


    // Method to show / hide invisible tiles based on proximity to the light source. Just before the destroy time it ensures that the sprites of  
    // any tiles affected by the light source are turned off before the lights source is destroyed.
    public void InvisibleTileShowHide()
    {
        Collider2D[] objectsInRadius = Physics2D.OverlapCircleAll(transform.position, visibleRadius);
        for (int i = 0; i < objectsInRadius.Length; i++)
        {
            // If the invis tiles are tagged correctly and within range, ignore collision so the light source can pass through and enable sprite
            // as long as the light source has not been destroyed.
            if (objectsInRadius[i].gameObject.tag == "InvisTiles" || objectsInRadius[i].gameObject.tag == "Trapdoor")
            {
                Physics2D.IgnoreCollision(GetComponent<Collider2D>(), objectsInRadius[i].GetComponent<Collider2D>());
                if(elapsedTime < destroyTime && Vector2.Distance(transform.position, objectsInRadius[i].transform.position) <= visibleRadius)
                {
                    objectsInRadius[i].GetComponent<SpriteRenderer>().enabled = true;
                }
                if(elapsedTime >= destroyTime || Vector2.Distance(transform.position, objectsInRadius[i].transform.position) > visibleRadius)
                {
                    objectsInRadius[i].GetComponent<SpriteRenderer>().enabled = false;
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    { 
        if (collision.gameObject)
        {
            //Hits enemy, it stops but doesn't block enemy.
            body.velocity = Vector2.zero;
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.gameObject.GetComponent<Collider2D>());
        }
    }
}

