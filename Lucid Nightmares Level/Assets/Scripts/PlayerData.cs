using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerData : MonoBehaviour
{
    public bool HasKey1 = false;
    public bool HasKey2 = false;
    public bool HasKey3 = false;

    public float maxHealth = 100;
    public float currentHealth;
    public float maxStamina = 40;
    public float currentStamina;
    public float staminaRegen = 0.15f;
    public float maxSpecial = 100;
    public float currentSpecial;
    public float specialRegen = 0.5f;

    public Vector3 checkpointPosition;

    GameController gameController;
    CanvasDisplay canvasDisplay;
    BossData bossData;

    private void Start()
    {
        ResetStats();
        checkpointPosition = transform.position;
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        bossData = GameObject.FindGameObjectWithTag("Boss").GetComponent<BossData>();
        canvasDisplay = GameObject.FindGameObjectWithTag("UI").GetComponent<CanvasDisplay>();
    }

    private void FixedUpdate()
    {
        if (currentSpecial < maxSpecial)
        {
            currentSpecial += specialRegen;
            if (currentSpecial > maxSpecial)
                currentSpecial = maxSpecial;
        }

        if (currentStamina < maxStamina)
        {
            currentStamina += staminaRegen;
        }

        //For boss fight, player can't shoot light source.
        if (gameController.BossFightActive)
        {
            currentSpecial = 0;
        }
        else if (gameController.BossFightActive == false && bossData.IsAlive == false)
        {
            currentSpecial += specialRegen;
            if (currentSpecial > maxSpecial)
                currentSpecial = maxSpecial;
        }
    }

    public void DeductHealth(int damage)
    {
        currentHealth -= damage;
        gameController.CheckIfGameOver();
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

        if (hitObject.tag == "Key3")
        {
            HasKey3 = true;
            Destroy(hitObject);
            canvasDisplay.DisplayKey();
        }

        if (hitObject.tag == "Mace")
        {
            damageInflicted = hitObject.GetComponent<MaceController>().damage;
            DeductHealth(damageInflicted);
        }

        if (hitObject.tag == "FireSkull")
        {
            damageInflicted = hitObject.GetComponent<FireSkullController>().damage;
            DeductHealth(damageInflicted);
            Destroy(hitObject);
        }

        if (hitObject.tag == "DarkSkull")
        {
            damageInflicted = hitObject.GetComponent<DarkSkullController>().damage;
            DeductHealth(damageInflicted);
            Destroy(hitObject);
        }

        if (hitObject.tag == "Checkpoint")
        {
            checkpointPosition = hitObject.transform.position;
        }

        if (hitObject.tag == "SawBlade")
        {
            damageInflicted = hitObject.GetComponent<SawBladeController>().damage;
            DeductHealth(damageInflicted);
        }

        if(hitObject.tag == "ZombieHitBox")
        {
            damageInflicted =  GameObject.FindGameObjectWithTag("Zombie").GetComponent<ZombieController>().damage;
            DeductHealth(damageInflicted);
        }

        if (hitObject.tag == "Health")
        {
            Destroy(hitObject);
            currentHealth += 20;
        }
        if(hitObject.tag == "WoodenSpike")
        {
            damageInflicted = 100;
            DeductHealth(damageInflicted);
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
