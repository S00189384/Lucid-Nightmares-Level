using System.Collections;
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

    public Vector3 checkpointPosition;

    GameController gameController;

    private void Start()
    {
        currentHealth = maxHealth;
        currentStamina = maxStamina;
        checkpointPosition = transform.position;
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    private void Update()
    {
 
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
        if(hitObject.tag == "Trapdoor")
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
            gameController.DeductHealth(100);
        }

        if(hitObject.tag == "FireSkull")
        {
            gameController.DeductHealth(40);
            Destroy(hitObject);
        }

        if(hitObject.tag == "Checkpoint")
        {
            checkpointPosition = hitObject.transform.position;
        }

    }


}
