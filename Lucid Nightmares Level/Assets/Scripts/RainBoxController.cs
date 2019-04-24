using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainBoxController : MonoBehaviour
{
    GameObject boss;
    public BoxCollider2D rainBox;
    public float rainSpeed = 2;

	// Use this for initialization
	void Start ()
    {
        boss = GameObject.FindGameObjectWithTag("Boss");
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
