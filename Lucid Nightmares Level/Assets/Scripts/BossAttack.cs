using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    //General
    public bool CanAttack;
    public int randomAttack;
    public float attackTimer;
    public float timeToAttack;

    //Attack1, homing exploding skull
    public Transform spawnPosition;
    public GameObject explodingSkull;

    //Attack2, rain attack
    public bool RainAttackActive;

    //Attack3, Shoot basic projectile towards player
    public GameObject objectToShoot;
    public float projectileSpeed = 2;

    GameObject player;
    BossMovement bossMovement;
    BossAnimationController bossAnimation;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        bossAnimation = GetComponent<BossAnimationController>();
	}
	
	// Update is called once per frame
	void Update()
    {
        if(CanAttack)
        {
            attackTimer += Time.deltaTime;
            if (attackTimer >= timeToAttack)
            {
                randomAttack = Random.Range(1, 4);

                if (randomAttack == 1)
                {
                    bossAnimation.SetState(BossState.Attack1);
                }
                else if (randomAttack == 2)
                {
                    bossAnimation.SetState(BossState.Attack2);
                }
                else
                {
                    bossAnimation.SetState(BossState.Attack3);
                }

            }


            if (Input.GetKeyDown(KeyCode.G))
            {
                RainAttackActive = true;
            }
            if(Input.GetKeyDown(KeyCode.H))
            {
                bossAnimation.SetState(BossState.Attack3);
                Debug.Log("h");
            }
        }		
	}

    //Attack 1
    public void SpawnHomingSkull()
    {
        Instantiate(explodingSkull, spawnPosition.transform.position, Quaternion.identity);
    }

    //Attack 2
    public void StartRain()
    {
        RainAttackActive = true;
    }

    //Attack 3
    public void ShootProjectile()
    {
        GameObject go = Instantiate(objectToShoot, transform.position, Quaternion.identity);
        go.GetComponent<Rigidbody2D>().velocity = (player.transform.position - transform.position).normalized * projectileSpeed;
    }

}
