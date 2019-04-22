using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FourthGhostState
{
    Idle, //0
    Dissapearing //1
}

public class FourthGhostController : MonoBehaviour
{
    Rigidbody2D body;


    public float moveSpeed = 3;

	// Use this for initialization
	void Start ()
    {
        body = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
