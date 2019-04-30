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
    public bool DialogueActive = false;
    public bool DialogueEnded;

    // Use this for initialization
    void Start ()
    {
        playerData = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerData>();
        bossData = GameObject.FindGameObjectWithTag("Boss").GetComponent<BossData>();
        DialogueEnded = false;
	}

    private void Update()
    {
        if(DialogueActive)
        {
            player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            player.GetComponent<PlayerAnimationController>().SetState(PlayerMovementState.Idle);

        }
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
