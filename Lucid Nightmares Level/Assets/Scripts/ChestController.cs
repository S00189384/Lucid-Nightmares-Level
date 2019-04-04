using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ChestState
{
    Closed, // 0
    Opening, // 1
}

public class ChestController : MonoBehaviour
{
    public GameObject player;
    public GameObject key;
    public bool keySpawned = false;
    public float openDistance = 5f;
    public ChestState chestState;
    ChestState previousChestState;
    Animator animator;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        SetState(ChestState.Closed);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(Vector2.Distance(transform.position,player.transform.position) <= openDistance)
        {
            SetState(ChestState.Opening);
            SpawnKey();

        }

        animator.SetInteger("ChestState", (int)chestState);
    }

    public void SetState(ChestState newState)
    {
        if (newState != chestState)
        {
            previousChestState = chestState;
            chestState = newState;
        }
    }

    void SpawnKey()
    {
        if(keySpawned == false)
        {
            GameObject go = Instantiate(key, transform.position, Quaternion.identity);
            go.GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 4);
        }

        keySpawned = true;

    }


}
