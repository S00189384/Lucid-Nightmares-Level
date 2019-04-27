using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainBoxController : MonoBehaviour
{
    BossAttack bossAttack;
    BossData bossData;
    GameObject boss;
    public BoxCollider2D rainBox;
    public GameObject rain;
    public float rainSpeed = 2.8f;
    public float rainTimer;
    public float rainSpawnTime = 0.5f;

	// Use this for initialization
	void Start ()
    {
        boss = GameObject.FindGameObjectWithTag("Boss");
        bossAttack = boss.GetComponent<BossAttack>();
        bossData = boss.GetComponent<BossData>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Follows boss if it's alive and spawns rain if attack is called.
        if(bossData.IsAlive)
        {
            transform.position = new Vector2(boss.transform.position.x, transform.position.y);

            if (bossAttack.RainAttackActive)
            {
                rainTimer += Time.deltaTime;
                if (rainTimer >= rainSpawnTime)
                {
                    SpawnRain();
                }
            }
            else
            {
                rainTimer = 0;
            }
        }

        //If boss is dead, destroy whole rain source.
        else
        {
            Destroy(gameObject);
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
