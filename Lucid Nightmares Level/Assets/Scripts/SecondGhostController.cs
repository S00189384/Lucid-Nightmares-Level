using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SecondGhostState
{
    Idle, //0
    Shooting, //1
    Dissapearing //2
}

public class SecondGhostController : MonoBehaviour
{
    Animator animator;
    public SecondGhostState ghostState;
    SecondGhostState previousGhostState;
    public GameObject player;
    public GameObject objectToShoot;
    public float distanceToShoot = 10;
    public float dissapearDistance = 4;
    public float shootSpeed = 2;
    public float elapsedTime;
    public float shootTime = 2;
    public float distanceToPlayer;

    public void Shoot()
    {
       GameObject go = Instantiate(objectToShoot, transform.position, Quaternion.identity);
       go.GetComponent<Rigidbody2D>().velocity = new Vector2(3, 0) * shootSpeed;
    }

    // Use this for initialization
    void Start ()
    {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

        if(distanceToPlayer <= distanceToShoot)
        {
            elapsedTime += Time.deltaTime;
            if(elapsedTime >= shootTime)
            {
                SetState(SecondGhostState.Shooting);
                elapsedTime = 0;
            }
        }

        if(distanceToPlayer <= dissapearDistance)
        {
            SetState(SecondGhostState.Dissapearing);
        }

        animator.SetInteger("SecondGhostState", (int)ghostState);
    }

    // So method can be called at end of animation.
    void DestroyGhost()
    {
        Destroy(gameObject);
    }

    public void SetState(SecondGhostState newState)
    {
        if (newState != ghostState)
        {
            previousGhostState = ghostState;
            ghostState = newState;
        }
    }

}
