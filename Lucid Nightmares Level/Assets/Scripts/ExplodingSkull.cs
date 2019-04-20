using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ExplodingSkullState
{
    Idle, //0
    Exploding, //1
    Exploded //2
}

public class ExplodingSkull : MonoBehaviour
{
    public ExplodingSkullState skullState;
    public GameObject player;
    public GameObject mimicObject;
    Animator animator;
    Rigidbody2D body;
    public float rotation = 2;
    public float distanceToPlayer;
    public float timer;
    public float explodeTime = 1.5f;
    public float explodeRadius = 3;
    public int damage = 100;
    public bool CanExplode = false;


	// Use this for initialization
	void Start ()
    {
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        skullState = ExplodingSkullState.Idle;
	}
	
	// Update is called once per frame
	void Update ()
    {
        distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
        if(distanceToPlayer < 3)
        {
            CanExplode = true;
        }
        if(CanExplode)
        {
            timer += Time.deltaTime;
            rotation += 2f;
            transform.Rotate(0, 0, rotation);
            skullState = ExplodingSkullState.Exploding;

            if (timer >= explodeTime)
            {
                if(gameObject.tag == "ExplodingSkull")
                {
                    body.velocity = Vector2.zero;
                    rotation = 0;
                    skullState = ExplodingSkullState.Exploded;
                }
                else if(gameObject.tag == "MimicSkull")
                {
                    Destroy(gameObject);
                    GameObject go = Instantiate(mimicObject, transform.position, Quaternion.identity);
                    go.GetComponent<Rigidbody2D>().velocity = new Vector2(-2, 2);
                }
     
            }
        }

        animator.SetInteger("ExplodingSkullState", (int)skullState);
    }

    //Called during animation.
    public void DestroySkull()
    {
        Destroy(gameObject);
    }
    public void Explosion()
    {
        Collider2D[] hitObjects = Physics2D.OverlapCircleAll(transform.position, explodeRadius);
        for (int i = 0; i < hitObjects.Length; i++)
        {
            if (hitObjects[i].tag == "Player")
                GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().DeductHealth(damage);
        }
    }
}
