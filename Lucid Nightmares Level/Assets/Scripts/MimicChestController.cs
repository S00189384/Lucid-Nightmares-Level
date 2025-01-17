﻿using System.Collections;
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
    Animator animator;
    GameObject player;
    public GameObject objectToSpawn;
    public float distanceToPlayer;
    public float distanceToOpen = 3;
    public bool SpawnedObject;

    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
        mimicChestState = MimicChestState.Closed;
	}
	
	// Update is called once per frame
	void Update ()
    {
        distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
        if(distanceToPlayer < distanceToOpen)
        {
            mimicChestState = MimicChestState.Open;
        }

        animator.SetInteger("MimicChestState", (int)mimicChestState);
	}

    // Method is called at end of animation.
    public void SpawnObject()
    {
        GameObject go = Instantiate(objectToSpawn, transform.position, Quaternion.identity);
        go.GetComponent<Rigidbody2D>().velocity = new Vector2(1.5f, 2);
    }
}
