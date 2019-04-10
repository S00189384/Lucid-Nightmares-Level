using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameController : MonoBehaviour
{
    PlayerData playerData;
    public GameObject player;

	// Use this for initialization
	void Start ()
    {
        playerData = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerData>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void CheckIfGameOver()
    {
        if(playerData.currentHealth <= 0)
        {
            TeleportToCheckpoint();
        }
    }

    public void DeductHealth(int damage)
    {
        playerData.currentHealth -= damage;
        CheckIfGameOver();
    }

    public void TeleportToCheckpoint()
    {
        player.transform.position = playerData.checkpointPosition;
    }



}
