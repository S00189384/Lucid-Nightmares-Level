using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    PlayerData playerData;
    PlayerMovement playerMovement;
    PlayerAnimationController playerAnimation;
    public GameObject lightSource;
    public float ProjectileForce = 5;
    Vector2 ProjectileDirection;

    public float specialDrain = 80;
    public float Attack1Drain = 15;
    public float Attack2Drain = 30;
    public float Attack3Drain = 35;


    // Use this for initialization
    void Start()
    {
        playerData = GetComponent<PlayerData>();
        playerMovement = GetComponent<PlayerMovement>();
        playerAnimation = GetComponent<PlayerAnimationController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShootSpecial()
    {
        if (playerData.currentSpecial == playerData.maxSpecial)
        {
            //Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //mousePos.z = -1;
            //GameObject go = Instantiate(lightSource, transform.position, Quaternion.identity);
            //go.GetComponent<Rigidbody2D>().velocity = (mousePos).normalized * ProjectileForce;
            //Physics2D.IgnoreCollision(GetComponent<Collider2D>(), go.GetComponent<Collider2D>());
            //playerData.currentSpecial -= playerData.specialDrain;
            ProjectileDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            GameObject go = Instantiate(lightSource, transform.position, Quaternion.identity);
            //go.position.z = -1;
            go.GetComponent<Rigidbody2D>().velocity = (ProjectileDirection).normalized * ProjectileForce;
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), go.GetComponent<Collider2D>());
            playerData.currentSpecial -= specialDrain;
        }
    }

    public void Attack1()
    {
        playerData.currentStamina -= Attack1Drain;
    }
    public void Attack2()
    {
        playerData.currentStamina -= Attack2Drain;
    }
    public void Attack3()
    {
        playerData.currentStamina -= Attack3Drain;
    }


}
