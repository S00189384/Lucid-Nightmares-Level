using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameController : MonoBehaviour
{
    PlayerData playerData;
    public GameObject player;

    public bool BossFightActive = false;

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

    //public void DeductHealth(int damage)
    //{
    //    playerData.currentHealth -= damage;
    //    CheckIfGameOver();
    //}

    public void TeleportToCheckpoint()
    {
        player.transform.position = playerData.checkpointPosition;
        playerData.ResetStats();
    }

}
