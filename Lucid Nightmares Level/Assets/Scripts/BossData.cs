using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossData : MonoBehaviour
{
    BossAnimationController bossAnimation;
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
        bossAnimation = GetComponent<BossAnimationController>();
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
            bossAnimation.SetState(BossState.PlayingDead);
        }

        //As soon as player is in boss room - boss wakes up.
        if(playerData.BossFightActive == true)
        {
            //Waking up animation plays. IsAwake set to true at end of animation. Then boss can move / attack.
            bossAnimation.SetState(BossState.WakingUp);
        }

        //Checking whether boss is Alive or not.
        if (currentHealth <= 0)
        {
            IsAlive = false;
            playerData.BossFightActive = false;

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
