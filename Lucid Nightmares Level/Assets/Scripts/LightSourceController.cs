using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSourceController : MonoBehaviour
{
    Rigidbody2D body;
    public float elapsedTime;
    public float destroyTime = 7;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update ()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= destroyTime)
            Destroy(gameObject);
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject)
            body.velocity = Vector2.zero;
    }

}
