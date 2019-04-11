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
        if(playerData.currentSpecial > 0)
        {
            ProjectileDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            GameObject go = Instantiate(lightSource, transform.position, Quaternion.identity);
            go.GetComponent<Rigidbody2D>().velocity = (ProjectileDirection).normalized * ProjectileForce;
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), go.GetComponent<Collider2D>());
            playerData.currentSpecial -= playerData.specialDrain;
        }

    }

}
