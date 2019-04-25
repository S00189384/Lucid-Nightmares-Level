using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    //General
    public bool Attacking = false;
    public int randomAttack;
    public float attackTimer;
    public float timeToAttack = 3.5f;

    //Attack1, homing exploding skull
    public Transform spawnPosition;
    public GameObject homingSkull;

    //Attack2, rain attack
    public bool RainAttackActive;
    public float rainAttackDurationTimer;
    public float timeToStopRain = 4;

    //Attack3, Shoot basic projectile towards player
    public GameObject objectToShoot;
    public float projectileSpeed = 2;

    GameObject player;
    BossMovement bossMovement;

	// Use this for initialization
	void Start ()
    {
        bossMovement = GetComponent<BossMovement>();
        player = GameObject.FindGameObjectWithTag("Player");
        randomAttack = Random.Range(1, 4);
    }

    void Update()
    {
        //If the player is in range & its time to attack, Attacking bool is true;
        //In BossMovement when Attacking bool is true, boss does a random attack.
        if(bossMovement.PlayerInRange)
        {
            attackTimer += Time.deltaTime;
            if (attackTimer >= timeToAttack)
                Attacking = true;
            else
                Attacking = false;
        }

        if(RainAttackActive)
        {
            rainAttackDurationTimer += Time.deltaTime;
            if (rainAttackDurationTimer >= timeToStopRain)
            {
                RainAttackActive = false;
                rainAttackDurationTimer = 0;
            }

        }
    }

    //Generates a random attack state animation which is used in BossMovement.
    public BossState GenerateRandomAttack()
    {
        BossState attackState;

        if (randomAttack == 1)
            attackState = BossState.Attack1;
        else if (randomAttack == 2)
            attackState = BossState.Attack2;
        else
            attackState = BossState.Attack3;

        return attackState;
    }

    //At the end of each attack animation, the next RNG attack is set up, and the timer is reset.
    public void ResetAttackTimer()
    {
        randomAttack = Random.Range(1, 4);
        attackTimer = 0;
    }


    //These methods are called at a particular frame in the animation.
    //Attack 1
    public void SpawnHomingSkull()
    {
        Instantiate(homingSkull, spawnPosition.transform.position, Quaternion.identity);
    }
    //Attack 2. 
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
