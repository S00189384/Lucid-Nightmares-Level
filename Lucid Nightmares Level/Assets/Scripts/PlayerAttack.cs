using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public BoxCollider2D hitBox;
    public Transform leftHitBoxPosition;
    public Transform rightHitBoxPosition;
    PlayerData playerData;
    PlayerAnimationController playerAnimation;
    public GameObject lightSource;
    public float ProjectileForce = 5;
    Vector2 ProjectileDirection;

    //Stamina Drain & Attack damage.
    public float specialDrain = 100;
    public float specialDamage = 10;
    public float Attack1Drain = 15;
    public float Attack1Damage = 5;
    public float Attack2Drain = 30;
    public float Attack2Damage = 10;
    public float Attack3Drain = 35;
    public float Attack3Damage = 15;
    public float DamageInflicted;


    // Use this for initialization
    void Start()
    {
        playerData = GetComponent<PlayerData>();
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
            ProjectileDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            GameObject go = Instantiate(lightSource, transform.position, Quaternion.identity);
            go.GetComponent<Rigidbody2D>().velocity = (ProjectileDirection).normalized * ProjectileForce;
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), go.GetComponent<Collider2D>());
            playerData.currentSpecial -= specialDrain;
            DamageInflicted = specialDamage;
        }
    }

    public void Attack1()
    {
        DamageInflicted = Attack1Damage;
        playerData.currentStamina -= Attack1Drain;
        hitBox.enabled = true;
    }

    public void Attack2()
    {
        DamageInflicted = Attack2Damage;
        playerData.currentStamina -= Attack2Drain;
        hitBox.enabled = true;
    }

    public void Attack3()
    {
        DamageInflicted = Attack3Damage;
        playerData.currentStamina -= Attack3Drain;
        hitBox.enabled = true;
    }

}
