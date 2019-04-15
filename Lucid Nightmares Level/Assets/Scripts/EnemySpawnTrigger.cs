using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnTrigger : MonoBehaviour
{
    public GameObject objectToSpawn;
    public Transform[] SpawnPoints;
    public int numSpawnPoints { get { return SpawnPoints.Length; } }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            for (int i = 0; i < SpawnPoints.Length; i++)
            {
                Instantiate(objectToSpawn, SpawnPoints[i].position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }
}
