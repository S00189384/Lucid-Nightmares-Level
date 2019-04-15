using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MimicChestState
{
    Closed, // 0
    Open, // 1
}


public class MimicChestController : MonoBehaviour
{
    public MimicChestState mimicChestState;
    MimicChestState previousMimicChestState;
    Animator animator;
    public GameObject objectToSpawn;
    GameObject player;
    Rigidbody2D body;
    public Vector2 distanceToPlayer;
    public float distanceToOpen = 3;
    public bool SpawnedObject;


    // Use this for initialization
    void Start ()
    {
        body = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
        mimicChestState = MimicChestState.Closed;

	}
	
	// Update is called once per frame
	void Update ()
    {
        if(Vector2.Distance(transform.position, player.transform.position) < distanceToOpen && SpawnedObject == false)
        {
            SpawnObject();
            mimicChestState = MimicChestState.Open;
        }

        animator.SetInteger("MimicChestState", (int)mimicChestState);
	}

    public void SpawnObject()
    {
        GameObject go = Instantiate(objectToSpawn, transform.position, Quaternion.identity);
        go.GetComponent<Rigidbody2D>().velocity = new Vector2(20, 25);
        SpawnedObject = true;
    }
}
