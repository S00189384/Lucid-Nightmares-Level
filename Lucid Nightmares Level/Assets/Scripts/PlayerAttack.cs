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
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = -1;
            GameObject go = Instantiate(lightSource, transform.position, transform.rotation);
            go.GetComponent<Rigidbody2D>().velocity = (mousePos).normalized * ProjectileForce;
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), go.GetComponent<Collider2D>());
            playerData.currentSpecial -= playerData.specialDrain;




            //ProjectileDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            //GameObject go = Instantiate(lightSource, transform.position, Quaternion.identity);
            ////go.position.z = -1;
            //go.GetComponent<Rigidbody2D>().velocity = (ProjectileDirection).normalized * ProjectileForce;
            //Physics2D.IgnoreCollision(GetComponent<Collider2D>(), go.GetComponent<Collider2D>());
            //playerData.currentSpecial -= playerData.specialDrain;
        }

    }

}
