using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossData : MonoBehaviour
{
    BossAnimationController bossAnimation;
    GameController gameController;
    PlayerData playerData;

    public bool IsAwake;

    public bool IsAlive;
    public float destroyTimer;
    public float timeToDestroyBoss = 6;

    public float currentHealth;
    public float maxHealth = 300;


    // Use this for initialization
    void Start ()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        bossAnimation = GetComponent<BossAnimationController>();
        playerData = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerData>();

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
        if(gameController.BossFightActive == true)
        {
            //Waking up animation plays. IsAwake set to true at end of animation. Then boss can move / attack.
            bossAnimation.SetState(BossState.WakingUp);
        }

        //Checking whether boss is Alive or not.
        if (currentHealth <= 0)
        {
            IsAlive = false;
            gameController.BossFightActive = false;

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerHitBox")
            currentHealth -= collision.gameObject.GetComponentInParent<PlayerAttack>().DamageInflicted;
    }
}
