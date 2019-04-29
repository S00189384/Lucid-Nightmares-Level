using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    //General
    public bool Attacking = false;
    public int randomAttack;
    public float attackTimer;
    public float timeToAttack;

    //Phase 1
    public float P1minAttackTime = 2.1f;
    public float P1maxAttackTime = 2.5f;

    //Phase 2
    public float P2minAttackTime = 1.5f;
    public float P2maxAttackTime = 2.1f;

    //Attack1, homing exploding skull
    public Transform spawnPosition;
    public GameObject homingSkull;

    //Attack2, rain attack
    public bool RainAttackActive;
    public float rainAttackDurationTimer;
    public float timeToStopRain = 6;
    public float minTimeToStopRain = 6;
    public float maxTimeToStopRain = 14;
    public int rainCasts = 0;

    //Attack3, Shoot basic projectile towards player
    public GameObject objectToShoot;
    public float projectileSpeed = 2;

    GameObject player;
    BossMovement bossMovement;
    BossData bossData;

	// Use this for initialization
	void Start ()
    {
        bossMovement = GetComponent<BossMovement>();
        bossData = GetComponent<BossData>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        //If the player is in range & its time to attack, Attacking bool is true.
        //In BossMovement when Attacking bool is true, boss does a random attack.
        if(bossMovement.PlayerInRange)
        {
            attackTimer += Time.deltaTime;
            if (attackTimer >= timeToAttack)
                Attacking = true;
            else
                Attacking = false;
        }

        //Rain attack animation turns RainAttackActive true.
        //Rain attack stops after a certain amount of time.
        if(RainAttackActive)
        {
            rainAttackDurationTimer += Time.deltaTime;
            if (rainAttackDurationTimer >= timeToStopRain)
            {
                RainAttackActive = false;
                rainAttackDurationTimer = 0;
                timeToStopRain = minTimeToStopRain;
                rainCasts = 0;
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

    //At the end of each attack animation, the next RNG attack is set up, the timer is reset.
    //Checks boss health and adjusts his time to attack based on health.
    public void ResetAttackTimer()
    {
        Attacking = false;
        attackTimer = 0;
        randomAttack = Random.Range(1, 4);
        if (bossData.currentHealth >= (bossData.maxHealth * 0.6))
            timeToAttack = Random.Range(P1minAttackTime, P1maxAttackTime);
        else
            timeToAttack = Random.Range(P2minAttackTime, P2maxAttackTime);
    }

    //These methods are called at a particular frame in the animation.
    //Attack 1
    public void SpawnHomingSkull()
    {
        Instantiate(homingSkull, spawnPosition.transform.position, Quaternion.identity);
    }

    //Attack 2. 
    //Sets rain attack active and keeps track of the number of rain casts.
    //If the boss decides to do another rain attack while rain is falling, the counter is increased & the time to stop rain is doubled.
    //MaxTimeToStopRain ensures that rain doesn't last for too long.
    public void StartRain()
    {
        RainAttackActive = true;
        rainCasts++;
        if (rainCasts >= 2)
        {
            timeToStopRain += minTimeToStopRain;
            if (timeToStopRain >= maxTimeToStopRain)
                timeToStopRain = maxTimeToStopRain;
        }
    }
    //Attack 3
    public void ShootProjectile()
    {
        GameObject go = Instantiate(objectToShoot, transform.position, Quaternion.identity);
        go.GetComponent<Rigidbody2D>().velocity = (player.transform.position - transform.position).normalized * projectileSpeed;
    }

}
