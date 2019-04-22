using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
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
        invisRoomTrigger = GameObject.FindGameObjectWithTag("InvisRoomTrigger").GetComponent<InvisRoomTrigger>();
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
	}

    public Vector3 PickRandomSpawnPosition()
    {
        float minX = spawnArea.bounds.min.x;
        float maxX = spawnArea.bounds.max.x;

        float randomX = Random.Range(minX, maxX);

        return new Vector3(randomX, transform.position.y);
    }

}
