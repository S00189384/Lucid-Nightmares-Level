using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawBladeController : MonoBehaviour
{
    Rigidbody2D body;
    public float rotation = 2;


	// Use this for initialization
	void Start ()
    {
        body = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Rotate(0,0,rotation);

	}
}
