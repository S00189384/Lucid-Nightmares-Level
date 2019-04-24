using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    //RainAttack (Attack2)
    BoxCollider2D rainBox;
    public GameObject rainParticles;


    BossMovement bossMovement;

    public bool CanAttack;

	// Use this for initialization
	void Start ()
    {
        bossMovement = GetComponent<BossMovement>();
	}
	
	// Update is called once per frame
	void Update()
    {
        if(CanAttack)
        {












        }


		
	}
}
