﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public bool HasKey1 = false;
    public bool HasKey2 = false;
    public bool HasKey3 = false;

    public float maxHealth = 100;
    public float currentHealth;
    public float maxStamina = 100;
    public float currentStamina;
    public float maxSpecial = 100;
    public float currentSpecial;
    public float specialDrain = 80;

    public Vector3 checkpointPosition;

    GameController gameController;

    private void Start()
    {
        ResetStats();
        checkpointPosition = transform.position;
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    private void Update()
    {
        if (currentSpecial < maxSpecial)
        {
            if(currentSpecial < 0)
            {
                currentSpecial = 0;
            }
            currentSpecial += 0.1f;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        HandleCollision(collision.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        HandleCollision(collision.gameObject);
    }

    public void HandleCollision(GameObject hitObject)
    {
        int damageInflicted;

        if (hitObject.tag == "Trapdoor")
        {
            Destroy(hitObject);
        }

        if(hitObject.tag == "Key3")
        {
            Destroy(hitObject);
            HasKey3 = true;
        }

        if(hitObject.tag == "Mace")
        {
            damageInflicted = hitObject.GetComponent<MaceController>().damage;
            gameController.DeductHealth(damageInflicted);
        }

        if(hitObject.tag == "FireSkull")
        {
            damageInflicted = hitObject.GetComponent<FireSkullController>().damage;
            gameController.DeductHealth(damageInflicted);
            Destroy(hitObject);
        }

        if(hitObject.tag == "Checkpoint")
        {
            checkpointPosition = hitObject.transform.position;
        }

        if(hitObject.tag == "SawBlade")
        {
            damageInflicted = hitObject.GetComponent<SawBladeController>().damage;
            gameController.DeductHealth(damageInflicted);
        }

    }

    // Sets all stats to max values.
    public void ResetStats()
    {
        currentHealth = maxHealth;
        currentStamina = maxStamina;
        currentSpecial = maxSpecial;
    }

}
