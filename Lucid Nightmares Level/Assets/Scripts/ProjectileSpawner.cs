using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    GameController gameController;
    InvisRoomTrigger invisRoomTrigger;
    BoxCollider2D spawnArea;
    Vector3 randomSpawnPosition;
    public GameObject objectToSpawn;
    public float timer;
    public float spawnTime = 2;
    public float minSpawnTime = 2;
    public float maxSpawnTime = 5.5f;

	// Use this for initialization
	void Start ()
    {
        spawnArea = GetComponent<BoxCollider2D>();
        spawnTime = spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
        invisRoomTrigger = GameObject.FindGameObjectWithTag("InvisRoomTrigger").GetComponent<InvisRoomTrigger>();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(invisRoomTrigger.PlayerNearby)
        {
            timer += Time.deltaTime;
            if (timer >= spawnTime)
            {
                Instantiate(objectToSpawn, PickRandomSpawnPosition(), Quaternion.identity);
                timer = 0;
                //Add variation to the time the projectiles drop.
                spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
            }
        }	

        //If the boss fight is active, destroy the spawners since player isn't going back.
        if(gameController.BossFightActive)
        {
            Destroy(gameObject);
        }
	}

    public Vector3 PickRandomSpawnPosition()
    {
        float minX = spawnArea.bounds.min.x;
        float maxX = spawnArea.bounds.max.x;
        float randomX = Random.Range(minX, maxX);
        return new Vector3(randomX, transform.position.y);
    }
}
