using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LightSourceController : MonoBehaviour
{
    Rigidbody2D body;
    public float elapsedTime;
    public float destroyTime = 7;
    public float visibleRadius = 5;
    public int numTilemaps;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update ()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= destroyTime)
            Destroy(gameObject);

        //TurnObjectVisible();

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

    public void TurnObjectVisible()
    {
        //Doesn't work for tilemaps. 

        //Collider2D[] hitObjects = Physics2D.OverlapCircleAll(transform.position, visibleRadius);
        //for (int i = 0; i < hitObjects.Length; i++)
        //{
        //    if (hitObjects[i].gameObject.tag == "InvisPlatform" && Vector2.Distance(transform.position, hitObjects[i].transform.position) <= visibleRadius)
        //    {
        //        hitObjects[i].GetComponent<SpriteRenderer>().enabled = true;
        //    }
        //    else if (hitObjects[i].gameObject.tag == "InvisPlatform" && Vector2.Distance(transform.position, hitObjects[i].transform.position) > visibleRadius)
        //    {
        //        hitObjects[i].GetComponent<SpriteRenderer>().enabled = false;
        //    }
        //}








        //Collider2D[] hitObjects = Physics2D.OverlapCircleAll(transform.position, visibleRadius);
        //for (int i = 0; i < hitObjects.Length; i++)
        //{
        //    if (hitObjects[i].GetComponent<TilemapRenderer>() == true)
        //    {
        //        if (hitObjects[i].gameObject.tag == "InvisTiles" && Vector2.Distance(transform.position, hitObjects[i].transform.position) <= visibleRadius)
        //        {
        //            hitObjects[i].GetComponent<TilemapRenderer>().enabled = true;
        //        }
        //        else if (hitObjects[i].gameObject.tag == "InvisTiles" && Vector2.Distance(transform.position, hitObjects[i].transform.position) > visibleRadius)
        //        {
        //            hitObjects[i].GetComponent<TilemapRenderer>().enabled = false;

        //        }
        //    }
        //}

    }
}
