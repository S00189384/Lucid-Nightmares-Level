using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ChestState
{
    Closed, // 0
    Opening, // 1
    Opened // 2
}

public class ChestController : MonoBehaviour
{
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

}
