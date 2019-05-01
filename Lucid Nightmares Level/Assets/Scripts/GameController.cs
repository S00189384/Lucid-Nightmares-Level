using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameController : MonoBehaviour
{
    PlayerData playerData;
    BossData bossData;
    public GameObject player;

    public bool BossFightActive = false;

    // Use this for initialization
    void Start ()
    {
        playerData = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerData>();
        bossData = GameObject.FindGameObjectWithTag("Boss").GetComponent<BossData>();
        //DialogueEnded = false;
	}

    public void CheckIfGameOver()
    {
        //If boss is active & player dies to boss, reset boss health.
        if (playerData.currentHealth <= 0 && BossFightActive)
        {
            bossData.currentHealth = bossData.maxHealth;
            TeleportToCheckpoint();
        }

        else if(playerData.currentHealth <= 0)
        {
            TeleportToCheckpoint();
        }
    }

    public void TeleportToCheckpoint()
    {
        player.transform.position = playerData.checkpointPosition;
        playerData.ResetStats();
    }

}
