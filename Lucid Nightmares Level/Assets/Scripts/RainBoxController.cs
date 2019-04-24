using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainBoxController : MonoBehaviour
{
    BossAttack bossAttack;
    Rigidbody2D body;
    GameObject boss;
    public BoxCollider2D rainBox;
    public GameObject rain;
    public float rainSpeed = 2;
    public float rainTimer;
    public float rainSpawnTime = 0.5f;

	// Use this for initialization
	void Start ()
    {
        boss = GameObject.FindGameObjectWithTag("Boss");
        bossAttack = boss.GetComponent<BossAttack>();
        body = GetComponent<Rigidbody2D>();	
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Follows boss.
        transform.position = new Vector2(boss.transform.position.x, transform.position.y);

        if(bossAttack.RainAttackActive)
        {
            rainTimer += Time.deltaTime;
            if(rainTimer >= rainSpawnTime)
            {
                SpawnRain();
            }

        }
	}

    public Vector2 GetRandomPosition()
    {
        float minX = rainBox.bounds.min.x;
        float maxX = rainBox.bounds.max.x;
        float randomX = Random.Range(minX, maxX);
        return new Vector2(randomX, transform.position.y);
    }

    public void SpawnRain()
    {
        GameObject go =  Instantiate(rain, GetRandomPosition(), Quaternion.identity);
        go.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -1) * rainSpeed;
        rainTimer = 0;
    }
}
