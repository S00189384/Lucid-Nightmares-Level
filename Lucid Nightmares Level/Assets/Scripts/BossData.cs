using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossData : MonoBehaviour
{
    PlayerData playerData;
    BossMovement bossMovement;

    public bool IsAwake;

    public bool IsAlive;
    public float destroyTimer;
    public float timeToDestroyBoss = 6;

    public float currentHealth;
    public float maxHealth = 300;


    // Use this for initialization
    void Start ()
    {
        playerData = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerData>();
        bossMovement = GetComponent<BossMovement>();

        currentHealth = maxHealth;
        IsAwake = false;
        IsAlive = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Checking whether boss is awake or not.
        if(IsAwake == false)
        {
            bossMovement.SetState(BossState.PlayingDead);
        }

        //As soon as player is in boss room - boss wakes up.
        if(playerData.InBossRoom == true)
        {
            //Waking up animation plays. IsAwake set to true at end of animation. Then boss can move / attack.
            bossMovement.SetState(BossState.WakingUp);
        }

        //Checking whether boss is Alive or not.
        if (currentHealth <= 0)
        {
            IsAlive = false;

            destroyTimer += Time.deltaTime;
            if (destroyTimer >= timeToDestroyBoss)
                Destroy(gameObject);
        }
        else
        {
            IsAlive = true;
        }

    }

    public void BossAwake()
    {
        IsAwake = true;
    }
}
