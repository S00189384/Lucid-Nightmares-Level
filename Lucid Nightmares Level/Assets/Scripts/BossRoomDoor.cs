using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoomDoor : MonoBehaviour
{
    Rigidbody2D body;
    BossData bossData;

    public Transform movePosition;
    public float moveSpeed = 2;


    // Use this for initialization
    void Start ()
    {
        bossData = GameObject.FindGameObjectWithTag("Boss").GetComponent<BossData>();
        body = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (bossData.IsAlive == false)
            body.MovePosition(Vector2.MoveTowards(transform.position, movePosition.transform.position, moveSpeed * Time.deltaTime));
	}
}
