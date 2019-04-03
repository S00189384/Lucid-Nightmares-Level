using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalController : MonoBehaviour
{

    public GameObject player;
    public float distanceFromPlayer;
    public float interactDistance = 1.9f;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        distanceFromPlayer = Vector2.Distance(transform.position, player.transform.position);

        //if(distanceFromPlayer <= interactDistance)
        //{

        //}
	}
}
