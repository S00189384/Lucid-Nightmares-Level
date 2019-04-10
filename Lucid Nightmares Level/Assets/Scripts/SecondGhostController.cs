using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SecondGhostState
{
    Idle, //0
    Dissapearing //1
}

public class SecondGhostController : MonoBehaviour
{
    public GameObject player;
    public GameObject objectToShoot;
    public float shootSpeed = 2;
    public float elapsedTime;
    public float shootTime = 2;

    public void Shoot()
    {
        Instantiate(objectToShoot, transform.position, Quaternion.identity);
        objectToShoot.GetComponent<Rigidbody2D>().velocity = new Vector2(2, 0);

    }





    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
